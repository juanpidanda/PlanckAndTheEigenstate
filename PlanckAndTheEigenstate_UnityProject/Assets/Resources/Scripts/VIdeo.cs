using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdeo : MonoBehaviour
{
    [SerializeField]private float timeVideo;
    private float currentTime;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
        if (currentTime >= timeVideo)
        {
            Application.LoadLevel("MainMenu");
        }

    }
}
