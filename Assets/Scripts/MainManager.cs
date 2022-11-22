using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static InventoryManager inventory;

    public static InventoryManager Inventory
    {
        get
        {
            if (inventory == null)
            {
                inventory = FindObjectOfType<InventoryManager>();
            }

            return inventory;
        }
        private set
        {
            inventory = value;
        }
    }
}