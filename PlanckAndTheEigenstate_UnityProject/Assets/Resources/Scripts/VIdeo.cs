using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdeo : MonoBehaviour
{
    private float timeVideo;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timeVideo = 26.0f;
    }

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
