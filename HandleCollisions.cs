using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Destroy game objects when they collide with eachother
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy"){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }    
    }
}
 
 