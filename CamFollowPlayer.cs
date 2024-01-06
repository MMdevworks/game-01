using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    //camera follows the player
    public Transform player;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 12, 0);
 
    }
}
