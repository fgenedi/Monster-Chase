using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // is called once per frame after update calc. are done
    void LateUpdate()
    {
        if (player == null) //!player is same as player==null
            return;
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if(tempPos.x>minX && tempPos.x<maxX)
            transform.position = tempPos;
    }
}
