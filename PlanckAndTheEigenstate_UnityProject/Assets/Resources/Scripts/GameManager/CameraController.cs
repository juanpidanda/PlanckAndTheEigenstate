using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetSpeed = 0f;
    public float yOffset = 0f;
    public Transform player;


    void LateUpdate()
    {
         Vector3 newPosition = new Vector3(player.position.x, player.position.y + yOffset, -10f);
       // Vector3 newPosition = player.position;
        transform.position = newPosition;
    }
}
