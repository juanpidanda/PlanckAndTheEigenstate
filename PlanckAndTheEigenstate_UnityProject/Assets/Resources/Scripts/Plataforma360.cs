using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma360 : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private float speed;
  
    void Update()
    {
        this.transform.RotateAround(pivot.position,Vector3.forward, speed * Time.deltaTime);
        this.transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
    }
}
