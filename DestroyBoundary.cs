using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoundary : MonoBehaviour
{

    // comment these in once player mvment is fixed then refactor with one variable, and use - 
    private float topBound = 30;
    // private float rightBound = 25;
    // private float leftBound = -25;
    // private float lowerBound = -25;    
    
    void Start()
    {
        
    }
    //destroy projectiles that fly past enemies and oob
    void Update()
    {
        if (transform.position.z > topBound) {
            Destroy(gameObject);
        // } else if (transform.position.z < lowerBound) {
        //     Destroy(gameObject);
            
        // } else if (transform.position.x < rightBound) {
        //     Destroy(gameObject);
        // } else if (transform.position.x < leftBound) {
        //     Destroy(gameObject);
    }
    }
}