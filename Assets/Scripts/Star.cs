using System;
using TMPro;
using UnityEngine;

public class Star : MonoBehaviour
{
    public TextMeshProUGUI _starCountLabel;
    public TextMeshProUGUI _allstarsCountLabel;
    public static int _star;
    public static int _allStars = 10;

    private void Start()
    {
        _allstarsCountLabel.text = _allStars.ToString();
    }

    void Update()
    {
        _starCountLabel.text = _star.ToString();
    }
}