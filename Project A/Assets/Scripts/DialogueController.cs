using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public List<string> currentDialogue;
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] int place; //Place is your current place in the dialogue, like index but this was more understandable to me
    [SerializeField] GameObject bottomPanel;
    public Image bottompanelSprite;

    private void Update()
    {
        if (bottomPanel.activeInHierarchy && Input.GetKeyUp(KeyCode.E))
        {
            ProgressDialogue();
        }
    }
    public void ActivateDialogue()
    {
        bottomPanel.SetActive(true);
        if (place < currentDialogue.Count)
        {
            textBox.text = currentDialogue[place];
        }
        else
        {
            EndDialogue();
        }

    }

    public void ProgressDialogue()
    {
        place += 1;
    }

    public void EndDialogue()
    {
        place = 0;
        bottomPanel.SetActive(false);
    }
}
