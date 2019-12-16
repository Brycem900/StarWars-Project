using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    private static readonly string WAVE_STARTS_MESSAGE = "Next Wave Starts in: ";
    private static readonly string WAVE_STARTED_MESSAGE = "Wave Started";
    private static readonly string DEATH_SCENE_NAME = "GameOver";

    public GameObject currentPlayer;
    public GameObject waveManagerObject;
    public Text health;
    public Text ammo;
    public Text wave;
    public Text scoreText;
    public Text waveStarts;
    public GameObject crosshair;

    private CombatManager combatManager;
    private WaveManager waveManager;
    private int score;
    private bool transitioning;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public GameObject Crosshair
    {
        get { return crosshair; }
    }

    void Awake()
    {
        currentPlayer = GameObject.Find("Player");
    }

    void Start()
    {
        combatManager = currentPlayer.GetComponent<CombatManager>();
        waveManager = waveManagerObject.GetComponent<WaveManager>();
        crosshair.SetActive(false);
        score = 0;
        transitioning = false;
    }
    
    void Update()
    {
        if(!transitioning)
        {
            health.text = combatManager.Health.ToString();
            wave.text = waveManager.Wave.ToString();
            var weaponComponent = combatManager.WeaponManager.WeaponComponent;
            if(weaponComponent is GunWeapon)
            {
                ammo.text = ((GunWeapon) weaponComponent).CurrentClip.ToString();
            }
            else
            {
                ammo.text = "/";
            }

            if(waveManager.CurrentWaveCountdown <= 0)
            {
                waveStarts.text = WAVE_STARTED_MESSAGE;
            }
            else
            {
                waveStarts.text = System.String.Format("{0} {1:#0.0}", WAVE_STARTS_MESSAGE, waveManager.CurrentWaveCountdown);
            }

            scoreText.text = score.ToString();
            crosshair.SetActive(combatManager.Aiming);

            if(combatManager.Health <= 0)
            {
                transitioning = true;
                Invoke("DeathScene", 8f);
            }
        }
    }

    void DeathScene()
    {
        var scoreKeeper = new GameObject("ScoreKeeper");
        scoreKeeper.AddComponent<ScoreKeeper>().score = Score;
        scoreKeeper.tag = "ScoreKeeper";
        SceneManager.LoadScene(DEATH_SCENE_NAME);
    }
}
