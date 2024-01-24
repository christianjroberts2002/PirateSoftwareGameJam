using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public event EventHandler OnRoundOver;

    private float startingSpawnWaitTime = 2f;
    

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
        StartCoroutine(EnemySpawnEveryXSeconds(startingSpawnWaitTime));
        DontDestroyOnLoad(gameObject);

        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;


        roundTime = GameManager.Instance.GetLevelTimer();
        Debug.Log(roundTime);
        spawnEnemyBool = false;

        enemySpawnTime = roundTime / enemyWaves;
        Debug.Log(enemySpawnTime);



    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        StopAllCoroutines();
        StartCoroutine(EnemySpawnEveryXSeconds(startingSpawnWaitTime));
        roundTime = GameManager.Instance.GetLevelTimer();
        Debug.Log(roundTime);
        spawnEnemyBool = false;

        enemySpawnTime = roundTime / enemyWaves;
        Debug.Log(enemySpawnTime);


    }




    private void Update()
    {
        SpawnEnemy();


    }

    private void SpawnEnemy() 
    {
        
        if (spawnEnemyBool)
        {
            Debug.Log("Spawn");
            for (int i = 0; i <= enemiesPerWave; i++)
            {

                
                Vector3 randonSpawnPos = GenerateRandomSpawnPos();
                Instantiate(enemy, randonSpawnPos , Quaternion.identity);
                spawnEnemyBool = false;
            }
            enemiesPerWave += enemiesPerWaveIncrease;
            StartCoroutine(EnemySpawnEveryXSeconds(enemySpawnTime));
        }
        
    }

    private Vector3 GenerateRandomSpawnPos()
    {
        float height = PaintGridSystem.Instance.GetGridHeight();
        float width = PaintGridSystem.Instance.GetGridWidth();
        Vector3 randonSpawnPos = new Vector3(UnityEngine.Random.Range(0, width), UnityEngine.Random.Range(0, height), 0);
        if (Vector3.Distance(randonSpawnPos, PlayerController.Instance.gameObject.transform.position) < 20f)
        {
            randonSpawnPos = GenerateRandomSpawnPos();
        }

        return randonSpawnPos;
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
        Debug.Log(time - Time.deltaTime);
        yield return new WaitForSeconds(time);
        Debug.Log("Spawn");
        spawnEnemyBool = true;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;

    }

}
