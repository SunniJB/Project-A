using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public Sprite itemSprite;
    [SerializeField] private InventoryController inventoryController;

    public void OnPickup() //Tell the inventory to fill the first available spot, then delete the item from the ground
    {
        inventoryController.FillSlot(itemSprite);
        Destroy(gameObject);
    }
}
