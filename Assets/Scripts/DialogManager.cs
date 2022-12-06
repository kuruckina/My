using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialog;
    public TextMeshProUGUI help;
    public string[] messege;
    private bool startDialog = false;
    private int i = 0;

    private void Start()
    {
        // help.text = "[R]";
        messege[0] = "Привет, Лиза";
        messege[1] = "Чтобы получить волшебную палочку, собери все кристаллы и жемчуг. Потом иди к порталу";
        messege[2] = "Наиди только корзину, чтобы ничего не рассыпать";
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
                    help.text = "[R]";
                }
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
            help.text = "[R]";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogPanel.SetActive(false);
        startDialog = false;
        help.text = "";
        i = 0;
    }
}