using System;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialog;
    public string[] messege;
    private bool startDialog = false;
    private int i = 0;

    private void Start()
    {
        messege[0] = "Привет, Лиза";
        messege[1] = "Чтобы получить волшебную палочку, собери все кристаллы и иди к порталу";
        messege[2] = "Найти только корзину, чтобы ничего не рассыпать";
        dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (startDialog)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                i++;
                if (i < 3)
                {
                    dialog.text = messege[i];
                }
                // dialog.text = messege[1];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            startDialog = true;
            dialog.text = messege[0];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogPanel.SetActive(false);
        startDialog = false;
        i = 0;
    }
}