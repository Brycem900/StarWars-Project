using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    private static readonly float SECONDS_BETWEEN_WAVES = 10;
    private static readonly string WAVE_STARTS_MESSAGE = "Next Wave Starts in: ";
    private static readonly string WAVE_STARTED_MESSAGE = "Wave Started";

    [SerializeField]
    private Transform spawnMiddle;

    [SerializeField]
    private float spawnRadius;

    [SerializeField]
    private List<GameObject> enemyTypes;

    [SerializeField]
    private List<float> enemySpawnRates;

    [SerializeField]
    private float scalingFactor = 1.2f;

    [SerializeField]
    private int startingEnemies = 5;

    [SerializeField]
    private int maxEnemies;

    public GameObject currentPlayer;

    [SerializeField]
    private Text waveUIText;

    [SerializeField]
    private Text waveStartsUIText;

    private System.Random random;
    private List<GameObject> enemies;

    private int currentNumberEnemies;
    private float previousNumberEnemies;
    private int wave;
    private float currentWaveCountdown;

    // Start is called before the first frame update
    void Start()
    {
        Assert.AreEqual(enemyTypes.Count, enemySpawnRates.Count);
        Assert.IsTrue(enemySpawnRates.All(x => x>= 0));
        Assert.AreApproximatelyEqual(enemySpawnRates.Sum(), 1, Mathf.Epsilon);

        var ordered = enemySpawnRates.OrderBy(x => x);
        Assert.IsTrue(enemySpawnRates.SequenceEqual(ordered));

        Assert.IsNotNull(currentPlayer);
        if(spawnMiddle == null)
        {
            spawnMiddle = gameObject.transform;
        }

        
        var r = new System.Security.Cryptography.RNGCryptoServiceProvider();
        var bytes = new byte[sizeof(System.Int32)];
        r.GetBytes(bytes);
        random = new System.Random(System.BitConverter.ToInt32(bytes, 0));
        enemies = new List<GameObject>();
        wave = 0;
        currentWaveCountdown = 0;
        StartCountDown();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWaveCountdown > 0)
        {
            currentWaveCountdown -= Time.deltaTime;
            if(currentWaveCountdown <= 0)
            {
                waveStartsUIText.text = WAVE_STARTED_MESSAGE;
                StartWave();
            }
            else
            {
                waveStartsUIText.text = System.String.Format("{0} {1:#0.0}", WAVE_STARTS_MESSAGE, currentWaveCountdown);
            }
        }
        else
        {
            if(enemies.Where(enemy => enemy == null).Count() == currentNumberEnemies)
            {
                StartCountDown();
            }
        }
    }

    public void StartCountDown()
    {
        currentWaveCountdown = SECONDS_BETWEEN_WAVES;
    }

    public void StartWave()
    {
        wave++;
        if(wave == 1)
        {
            previousNumberEnemies = startingEnemies;
        }
        else
        {
            previousNumberEnemies = previousNumberEnemies * scalingFactor;
        }

        currentNumberEnemies = (int) previousNumberEnemies;

        if(currentNumberEnemies > maxEnemies)
        {
            currentNumberEnemies = maxEnemies;
        }

        enemies.Clear();
        for(var i = 0; i < currentNumberEnemies; i++)
        {
            enemies.Add(SpawnEnemy(PickEnemy()));
        }

        waveUIText.text = wave.ToString();
    }

    private GameObject PickEnemy()
    {
        var roll = random.NextDouble();
        var cumulative = 0.0;
        for(var i = 0; i < enemyTypes.Count; i++)
        {
            cumulative += enemySpawnRates[i];
            if(roll < cumulative)
            {
                return enemyTypes[i];
            }
        }

        return null;
    }

    private GameObject SpawnEnemy(GameObject enemyType)
    {
        var newPosition = ((Vector3) (Random.insideUnitCircle * spawnRadius)) + spawnMiddle.position;
        newPosition.y = spawnMiddle.position.y;
        newPosition.z = (float) (spawnRadius * random.NextDouble() * (random.Next(0, 2) * 2 - 1)) + spawnMiddle.position.z;

        var spawnedEnemy = Instantiate<GameObject>(enemyType, newPosition, Quaternion.identity);
        spawnedEnemy.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = currentPlayer.transform;
        spawnedEnemy.AddComponent<CombatManager>();

        return spawnedEnemy;
    }
}
