using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReceiver : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    private void Update()
    {
        Debug.Log(this.tag);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.CompareTag("Dialogue"))
        {
            Debug.Log("Entered");
        }
    }
}
