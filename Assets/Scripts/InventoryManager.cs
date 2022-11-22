using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    [SerializeField] private UIObject[] objects;

    private void Start()
    {
        Inventory.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);

            if (Inventory.activeSelf)
            {
                UpdateUI();
            }
        }
    }

    public void AddItem(GameObject objectInScene)
    {
        foreach (UIObject obj in objects)
        {
            if (objectInScene.Equals(obj.myObject()))
            {
                obj.State = true;
                break;
            }
        }

        if (Inventory.activeSelf)
        {
            UpdateUI();
        }
    }

    private void UpdateUI() // обновление инвентаря
    {
        foreach (UIObject obj in objects) 
        {
            obj.UpdateImage(); 
        }
    }
}