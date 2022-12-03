using TMPro;
using UnityEngine;

public class CheckAnimationBox : MonoBehaviour
{
    [SerializeField] private JoinAnimation _joinAnimation;

    public GameObject dialogPanel;
    public TextMeshProUGUI dialog;
    public string messege;

    public void AnimationEnded()
    {
        _joinAnimation.AnimationEnded();
    }

    public void SpawnPrefab()
    {
        _joinAnimation.SpawnPrefab();
    }

    private void Start()
    {
        messege = "Чтобы открыть сундук поставь корзину и нажми [F]";
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);

            dialog.text = messege;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        dialogPanel.SetActive(false);
    }
}