using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private UIObject[] objects;
    // [SerializeField] private UIObject _uiStar;
    // private int _itemCount;

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
            // for (int i = 0; i < obj.objectsInScene.Length; i++)
            // {
            //     if (objectInScene.Equals((obj.objectsInScene[i]))) ;
            //     {
            //         Debug.Log(obj);
            //         if (obj.objectsInScene[i].CompareTag("starItem"))
            //         {
            //             _itemCount++;
            //             _uiStar.SetCount(_itemCount);
            //         }
            //         obj.State = true;
            //         break;
            //     }
            // }

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