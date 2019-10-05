public class GatherableInteractable : Interactable
{
    public Inventory playerInventory;
    public Item item;

    public override void OnInteract()
    {
        playerInventory.AddToInventory(item);
        Destroy(gameObject);
    }
}
