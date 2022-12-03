using TMPro;
using UnityEngine;

public class Star : MonoBehaviour
{
    public TextMeshProUGUI _starCountLabel;
    public static int _star;
    public static int _allStars = 1;

    void Update()
    {
        _starCountLabel.text = _star.ToString();
    }
}