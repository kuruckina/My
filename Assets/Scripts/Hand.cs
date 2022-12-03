using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private IKAnimation playerIK;
    private Transform interactObject;
    // private Transform inHand;
    public static Transform inHand;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ThroughItem();
        }
    }

    private void FixedUpdate()
    {
        CheckDistance(); // проверка дистанции с объектом
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item") && inHand)
        {
            interactObject = other.transform;
            Debug.Log(interactObject);
            playerIK.StartInteraction(other.gameObject.transform.position);
        }

        if (other.CompareTag("itemForTransfer"))
        {
            interactObject = other.transform;
            Debug.Log(interactObject);
            playerIK.StartInteraction(other.gameObject.transform.position);
        }

        if (other.CompareTag("starItem"))
        {
            interactObject = other.transform;
            Debug.Log(interactObject);
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
        if (interactObject != null && Vector3.Distance(transform.position, interactObject.position) > 5)
        {
            Debug.Log(interactObject);
            interactObject = null;
            playerIK.StopInteraction();
        }
    }

    private void TakeItemInPocket(GameObject item)
    {
        playerIK.StopInteraction();
        Destroy(item);
        MainManager.Inventory.AddItem(item);

        if (item.name == "Sphere")
        {
            MainManager.Messenger.WriteMessage("Вы подобрали жемчуг");
        }
        else
        {
            MainManager.Messenger.WriteMessage("Вы подобрали кристалл");
        }
    }

    private void TakeStar(GameObject item)
    {
        playerIK.StopInteraction();
        Star._star++;
        Destroy(item);
        if (Star._star == Star._allStars)
        {
            MainManager.game.WinGame();
        }
    }

    private void TakeItemInHand(Transform item)
    {
        item.GetComponent<BasketRb>().Kinematic(true);
        inHand = item; // запоминаем объект для взаимодействия
        inHand.parent = transform; // делаем руку родителем объекта
        inHand.localPosition = new Vector3(0.051f, 0.012f, -0.019f);
        inHand.localEulerAngles = new Vector3(0.058f, -0.4f, 87.6f);
        this.StartFrameTimer(5, playerIK.StopInteraction);
        MainManager.Messenger.WriteMessage("Вы подобрали корзину");
    }

    private IEnumerator ReadyToTake()
    {
        yield return new WaitForSeconds(2f);
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