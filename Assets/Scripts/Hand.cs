using System.Collections;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private IKAnimation playerIK; 
    private Transform interactObject; 
    private Transform inHand;

    private void FixedUpdate()
    {
        CheckDistance(); // проверка дистанции с объектом
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ThroughItem();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("item") || other.CompareTag("itemForTransfer"))
        {
            interactObject = other.transform; 
            playerIK.StartInteraction(other.gameObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item"))
        {
            TakeItemInPocket(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("itemForTransfer") && !inHand)
        {
            TakeItemInHand(collision.gameObject.transform);
        }
    }

    // метод для проверки дистанции, чтобы была возможность прекратить взаимодействие с объектом при отдалении
    private void CheckDistance()
    {
        if (interactObject != null && Vector3.Distance(transform.position, interactObject.position) > 2)
        {
            interactObject = null; 
            playerIK.StopInteraction(); 
        }
    }

    private void TakeItemInPocket(GameObject item)
    {
        playerIK.StopInteraction(); 
        Destroy(interactObject.gameObject); 
        MainManager.Inventory.AddItem(interactObject.gameObject);
    }

    private void TakeItemInHand(Transform item) 
    {
        inHand = item; // запоминаем объект для взаимодействия
        inHand.parent = transform; // делаем руку родителем объекта
        inHand.localPosition = new Vector3(0.235f, -0.01f, 0.001f); 
        inHand.localEulerAngles = new Vector3(0.058f, -0.4f, 87.6f); 
        playerIK.StopInteraction(); 
    }

    private IEnumerator ReadyToTake()
    {
        yield return null; 
        inHand = null;
    }

    private void ThroughItem()
    {
        if (inHand != null) // если персонаж держит объект
        {
            inHand.parent = null; // отвязываем объект     
            StartCoroutine(ReadyToTake()); 
        }
    }
}