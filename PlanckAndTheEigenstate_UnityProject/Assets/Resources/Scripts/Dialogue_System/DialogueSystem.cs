using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] float timeForNextWord;
    [SerializeField] float timeForNextDialogue;
    [SerializeField] float timeToWaitBeforeDialogue;
    [TextArea]
    public string[] dialogues;
    public TMP_Text text;
    bool isAvailable;
    private void Start()
    {
        isAvailable = true;
        text.text = "";
    }

    public void DisplayDialogues(string[] newDialogues)
    {
        if (isAvailable)
        {
            isAvailable = false;
            dialogues = newDialogues;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        foreach(string dialogue in dialogues)
        {
            foreach (char character in dialogue)
            {
                text.text += character;
                yield return new WaitForSeconds(timeForNextWord);
            }
            yield return new WaitForSeconds(timeToWaitBeforeDialogue);
            text.text = "";
            yield return new WaitForSeconds(timeForNextDialogue);
        }
        isAvailable = true;
    }
}
