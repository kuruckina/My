using System.Collections;
using UnityEngine;

public class Princess : MonoBehaviour
{
    Animator animbot;
    // public GameObject dialogue;

    [SerializeField] private GameObject player;
    float weight = 0f;

    enum states
    {
        waiting, // ожидает
        dialog, // диалог
    };

    states state = states.waiting; // изначальное состояние ожидания

    void Start()
    {
        animbot = GetComponent<Animator>(); // берем компонент аниматора
        StartCoroutine(Wait()); // запускаем корутину ожидания
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case (states.waiting):
            {
                if (PlayerNear()) PrepareToDialog();
                break;
            }

            case states.dialog:
            {
                if (!PlayerNear()) StartCoroutine(Wait());
                break;
            }
        }
    }

    bool PlayerNear()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 10) return true;
        else return false;
    }

    void PrepareToDialog()
    {
        animbot.SetTrigger("hello");

        // dialogue.gameObject.SetActive(true);

        state = states.dialog;
    }

    void OnAnimatorIK()
    {
        if (state == states.dialog)
        {
            if (weight < 1) weight += 0.1f;
            animbot.SetLookAtWeight(weight);
            animbot.SetLookAtPosition(player.transform.TransformPoint(Vector3.up * 1.5f));
        }
        else if (weight > 0)
        {
            weight -= 0.1f;
            animbot.SetLookAtWeight(weight);
            animbot.SetLookAtPosition(player.transform.TransformPoint(Vector3.up * 1.5f));
        }
    }

    IEnumerator Wait() // корутина ожидания
    {
        state = states.waiting; // указываем, что бот перешел в режим ожидания
        yield return new WaitForSeconds(10f); // ждем 10 секунд
    }
}