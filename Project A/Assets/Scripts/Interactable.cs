using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject interactKey, objectiveTextBox;
    [SerializeField] private bool canInteract;
    [SerializeField] GameManager gameManager;
    public string newObjectiveText;
    [Header("For talkables")]
    public List<string> dialogueLines;
    [SerializeField] DialogueController dialogueController;
    public Sprite talkableSprite;
    [Header("For interact spots")]
    public Sprite correctItemSprite;
    [SerializeField] InventoryController inventoryController;

    private void Start()
    {
        interactKey = transform.GetChild(0).gameObject; //get the little "Press E" prompt
        if (dialogueController == null) //Failsafe, everything is assigned in the inspector but just in case
        {
            dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
        }
        if (inventoryController == null)
        {
            inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectiveTextBox = GameObject.Find("ObjectiveText");
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
            Debug.Log("Item is interacted with");
            gameObject.GetComponent<Item>().OnPickup();
        }
        if (gameObject.tag == "InteractSpot")
        {
            //Tell the controller "I'm looking for this item, get back to me if you find it"
            inventoryController.CheckForitem(correctItemSprite); 

            //Make Huxley comment/hint if you don't have the right item
            if (inventoryController.failedToFindItem) 
            {
                dialogueController.currentDialogue = dialogueLines;
                dialogueController.bottompanelSprite.sprite = talkableSprite;
                dialogueController.ActivateDialogue();
                inventoryController.failedToFindItem = false;
            } else if (inventoryController.failedToFindItem == false)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ItemUsed");
            }
        }
        if (newObjectiveText != null)
        {
            gameManager.objectiveTextBox = objectiveTextBox;
            gameManager.ChangeObjective(newObjectiveText);
        }
    }


}
