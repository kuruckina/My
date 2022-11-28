using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject _deathPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _deathPanel.SetActive(true);
        }
    }
}