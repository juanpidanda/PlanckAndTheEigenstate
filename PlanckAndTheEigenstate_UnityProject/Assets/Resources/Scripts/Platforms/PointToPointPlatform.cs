using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointPlatform : MonoBehaviour
{

    public GameObject platform;
    public float movementSpeed;
    public Transform[] checkpoints;
    [SerializeField] int currentCheckpointID;
    [SerializeField] Transform currentCheckpointToGo;
    Vector3 direction;

    private void Start()
    {
        currentCheckpointID = 0;
        currentCheckpointToGo = checkpoints[currentCheckpointID];
    }
    private void FixedUpdate()
    {
        MoveToCheckpoint();
    }

    void MoveToCheckpoint()
    {
        

        platform.transform.Translate(movementSpeed * Time.deltaTime * direction);

        if(Vector3.Distance(platform.transform.position, currentCheckpointToGo.position) < 1.0f)
        {
            GetNextCheckpoint();
        }
    }
    void GetNextCheckpoint()
    {
        currentCheckpointID++;
        if(currentCheckpointID >= checkpoints.Length)
        {
            currentCheckpointID = 0;
        }
        currentCheckpointToGo = checkpoints[currentCheckpointID]; 
        direction = currentCheckpointToGo.position - platform.transform.position;
    }
}
