using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GuiManager : MonoBehaviour
{
    private static readonly string WAVE_STARTS_MESSAGE = "Next Wave Starts in: ";
    private static readonly string WAVE_STARTED_MESSAGE = "Wave Started";

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

    public int Score
    {
        get { return score; }
        set { score = value; }
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
    }
    
    void Update()
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
    }
}
