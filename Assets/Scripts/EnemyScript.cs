using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float maxRandomEnemySpeed;
    [SerializeField] private float enemySpeed;

    [SerializeField] private float minRandomEnemySpeed;
    [SerializeField] private float maxEnemySpeed;

    [SerializeField] private float enemySpeedIncrease;

    private Rigidbody2D enemyRB;
    private Vector2 playerPosition;

    public bool rbMovement;

    [SerializeField] private LayerMask friendlyPaint;
    [SerializeField] private LayerMask enemyPaint;

    public enum OnFootTile
    {
        Neutral,
        Friendly,
        Enemy
    }

    public OnFootTile onFootTile;

    // Start is called before the first frame update
    void Start()
    {
        maxEnemySpeed = Random.Range(minRandomEnemySpeed, maxRandomEnemySpeed);
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollowPlayer();
        //EnemyDetectPaintWalkingOn();
    }

    private void EnemyFollowPlayer()
    {
        var t = GameObject.Find("Player").transform.position;
        // print(t);
        playerPosition = new Vector2(t.x, t.y);
        // print(playerPosition);
        Vector3 enemyDirection = playerPosition - enemyRB.position;
        //print(enemyDirection);
        enemyDirection.Normalize();
        if(enemySpeed <= maxEnemySpeed)
        {
            enemySpeed += enemySpeedIncrease;
        }

        var result = enemyDirection * enemySpeed * Time.deltaTime;
        enemyRB.position += new Vector2(result.x, result.y);
    }

    private void EnemyDetectPaintWalkingOn()
    {
        float feetOffset = -.6f;
        float feetMaxDistance = .12f;
        Vector3 feetposition = transform.position + new Vector3(0, feetOffset, 0);
        Debug.DrawRay(feetposition, Vector3.down * feetMaxDistance, Color.black);
        if (Physics2D.Raycast(feetposition, Vector3.down, feetMaxDistance, enemyPaint))
        {
            onFootTile = OnFootTile.Enemy;
        }
        else if (Physics2D.Raycast(feetposition, Vector3.down, feetMaxDistance, friendlyPaint))
        {
            onFootTile = OnFootTile.Friendly;
        }
        else
        {
            onFootTile = OnFootTile.Neutral;
        }
    }

    private void RandomEnemySpawn()
    {

    }
    
    public OnFootTile GetOnFootTile()
    {
        return onFootTile;
    }

    public void SetEnemySpeed(float enemySpeed)
    {
        this.enemySpeed = enemySpeed;
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }
}
