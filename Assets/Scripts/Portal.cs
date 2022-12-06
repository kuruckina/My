using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int index;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && InventoryManager.item == InventoryManager.allObj)
        {
            // MainManager.Messenger.WriteMessage("Вы все собрали");
            SceneManager.LoadSceneAsync(2);
        }
        else if(InventoryManager.item != InventoryManager.allObj)
        {
            MainManager.Messenger.WriteMessage("Соберите все предметы");
        }
    }
}