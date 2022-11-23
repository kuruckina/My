using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private IKAnimation playerIK;
    private StarUI _starUI;
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
        if (other.CompareTag("item") && inHand)
        {
            interactObject = other.transform;
            playerIK.StartInteraction(other.gameObject.transform.position);
        }

        if (other.CompareTag("starItem"))
        {
            interactObject = other.transform;
            playerIK.StartInteraction(other.gameObject.transform.position);
        }

        if (other.CompareTag("itemForTransfer"))
        {
            interactObject = other.transform;
            playerIK.StartInteraction(other.gameObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("item") && inHand)
        {
            TakeItemInPocket(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("starItem"))
        {
            TakeStar(collision.gameObject);
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
    
    private void TakeStar(GameObject item)
    {
        playerIK.StopInteraction();
        _starUI.GetComponent<StarUI>().AddStar(item);
        Destroy(interactObject.gameObject);
    }

    private void TakeItemInHand(Transform item)
    {
        item.GetComponent<BasketRb>().Kinematic(true);
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
            inHand.GetComponent<BasketRb>().Kinematic(false);
            inHand.parent = null; // отвязываем объект 
            StartCoroutine(ReadyToTake());
        }
    }
}