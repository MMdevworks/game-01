using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
    public int pointValue;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    // Destroy game objects when they collide with eachother
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateScore(pointValue);
        }    
    }
}
 
 