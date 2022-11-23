using TMPro;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    public GameObject[] _stars;
    [SerializeField] private TextMeshProUGUI _countLabel; 
    private int _itemCount;

    public void AddStar(GameObject  obj)
    {
        foreach (GameObject star in _stars)
        {
            if (obj.Equals(star))
            {
                _itemCount++;
                _countLabel.text = _itemCount.ToString();
            }
        }
    }
}