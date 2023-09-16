using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointPlatform : MonoBehaviour
{
    public float movementSpeed;
    public int currentCheckPointToGo;
    public Transform[] checkpoints;

    private void Start()
    {
        currentCheckPointToGo = 0;
    }

}
