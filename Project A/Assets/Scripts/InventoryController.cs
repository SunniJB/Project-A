using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject[] itemSlots;
    public bool failedToFindItem;



    public void FillSlot(Sprite sprite) // Go through a loop that goes until it hits the first unfilled item slot. Mark that one as filled and add a picture. 
    {
        for (var i = 0; i < itemSlots.Length; i++) 
        {
            if (itemSlots[i].GetComponent<ItemSlot>().filled == false)
            {
                itemSlots[i].GetComponent<ItemSlot>().filled = true;
                itemSlots[i].GetComponent<ItemSlot>().itemSprite.sprite = sprite;
                return;
            }
        }
    }

    public void CheckForitem(Sprite correctSprite) //Look through the inventory spots to see what's there. InteractSpots tell this script what its looking for.
    {
        for (var i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].GetComponent<Image>().sprite == correctSprite) //if the item the interactSpot is looking for is found
            {
                failedToFindItem = false;
                return;
            } else
            {
                failedToFindItem = true;
                return;
            }
        }
    }


}
