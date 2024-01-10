using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody enemyRb;
    private GameObject player;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //initialization for component and game object
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update() {
        if(gameManager.isGameActive){
            //enemy follows players position by subtracting its own position from players position, use normalize to prevent increased acceleration over greater distances
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            //ratate to look at player
            transform.LookAt(player.transform);
        }
        
        if(transform.position.y < -10) {
            Destroy(gameObject);
        }
    }
}


