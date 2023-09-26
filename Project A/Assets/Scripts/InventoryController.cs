using System;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject[] itemSlots;

    // Go through a loop that goes until it hits the first unfilled item slot. Mark that one as filled. 

    public void FillSlot(Sprite sprite)
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


}
