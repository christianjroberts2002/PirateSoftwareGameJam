using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float enemySpeed = 0.1f;

    private Rigidbody2D enemyRB;
    private Vector2 playerPosition;

    public bool rbMovement;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rbMovement)
        {
            var t = GameObject.Find("Player").transform.position;
            // print(t);
            playerPosition = new Vector2(t.x, t.y);
            // print(playerPosition);
            Vector3 enemyDirection = playerPosition - enemyRB.position;
            //print(enemyDirection);
            enemyDirection.Normalize();
            var result = enemyDirection * enemySpeed * Time.deltaTime;
            transform.position += result;
        }
        else
        {
            var t = GameObject.Find("Player").transform.position;
            // print(t);
            playerPosition = new Vector2(t.x, t.y);
            // print(playerPosition);
            Vector3 enemyDirection = playerPosition - enemyRB.position;
            //print(enemyDirection);
            enemyDirection.Normalize();
            var result = enemyDirection * enemySpeed * Time.deltaTime;
            enemyRB.position += new Vector2(result.x, result.y);
            
        }

    }
}
