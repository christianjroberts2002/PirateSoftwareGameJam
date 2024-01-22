using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{

    [SerializeField] List<GameObject> enemies;
    public GameObject enemy;


    public static EnemyManagerScript Instance;

    private bool spawnEnemyBool;

    [SerializeField] private int enemiesPerWave;
    [SerializeField] private int enemyWaves;
    [SerializeField] private int enemiesPerWaveIncrease;

    [SerializeField] private float enemySpawnTime;

    [SerializeField] private float roundTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        spawnEnemyBool = true;

        enemySpawnTime = roundTime / enemyWaves;
    }

    private void Update()
    {


        SpawnEnemy();
       
        
    }

    private void SpawnEnemy() {

        if (spawnEnemyBool)
        {
            for (int i = 0; i <= enemiesPerWave; i++)
            {

                float height = PaintGridSystem.Instance.GetGridHeight();
                float width = PaintGridSystem.Instance.GetGridWidth();
                Instantiate(enemy, new Vector3(Random.Range(0, width), Random.Range(0, height), 0), Quaternion.identity);
                spawnEnemyBool = false;
            }
            enemiesPerWave += enemiesPerWaveIncrease;
            StartCoroutine(EnemySpawnEveryXSeconds(enemySpawnTime));
        }
        
    }

    public void EnemySpawned(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void EnemyDied(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public IEnumerator EnemySpawnEveryXSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        spawnEnemyBool = true;
    }

}
