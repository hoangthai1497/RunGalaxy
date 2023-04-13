using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public Transform playerPos;
    public float offset = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Camfollow();
    }

    public void Camfollow()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.position.z - offset);
        
    }
}
