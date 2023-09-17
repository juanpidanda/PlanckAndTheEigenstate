using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    [SerializeField] string[] dialogues;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            other.GetComponent<RotationalGun>().dialogueSystem.DisplayDialogues(dialogues);
            this.gameObject.SetActive(false);
        }
    }
    
}
