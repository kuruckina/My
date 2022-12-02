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
            if (index == 1)
            {
                SceneManager.LoadSceneAsync(2);
            }
            if (index == 2)
            {
                SceneManager.LoadSceneAsync(1);
            }
           
        }
        else
        {
            MainManager.Messenger.WriteMessage("Соберите все кристаллы");
        }
    }
}