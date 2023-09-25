using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject interactKey;
    [SerializeField] private bool canInteract;
    public List<string> dialogueLines;
    [SerializeField] DialogueController dialogueController;
    public Sprite talkableSprite;

    private void Start()
    {
        interactKey = transform.GetChild(0).gameObject;
        if (dialogueController == null ) 
        {
            dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
        }
    }

    private void Update()
    {
        if (canInteract && Input.GetKeyUp(KeyCode.E))
        {
            Interact();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactKey.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactKey.SetActive(false);
            canInteract = false;
        }
    }

    private void Interact()
    {
        if (gameObject.tag == "Talkable")
        {
            dialogueController.currentDialogue = dialogueLines;
            dialogueController.bottompanelSprite.sprite = talkableSprite;
            dialogueController.ActivateDialogue();
        }
        if (gameObject.tag == "Item")
        {
            //Inventory logic
        }
        if (gameObject.tag == "InteractSpot")
        {
            //Using items logic
        }
    }
}
