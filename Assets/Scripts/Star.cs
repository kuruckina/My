using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public TextMeshProUGUI _starCountLabel;
    public static int _star;
    void Update()
    {
        _starCountLabel.text = _star.ToString();
    }
}