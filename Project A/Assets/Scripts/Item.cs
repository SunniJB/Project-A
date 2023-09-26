using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public Sprite itemSprite;
    [SerializeField] private InventoryController inventoryController;
    private void Start()
    {
        //Item has a sprite. Put the sprite in the first inventory slot. If first inventory slot is taken, put in the next available.
        // remove item from its place on the ground.

    }

    public void OnPickup()
    {
        inventoryController.FillSlot(itemSprite);
        Destroy(gameObject);
    }
}
