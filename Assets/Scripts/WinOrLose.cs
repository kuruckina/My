using System;
using TMPro;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _animation;
    public GameObject _winPanel;
    public GameObject _losePanel;
    public GameObject _basket;

    private void Awake()
    {
        if (GameManager._win)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    private void Win()
    {
        _animation.HappyAnimation();
        _winPanel.SetActive(true);
        _basket.SetActive(true);
    }
    private void Lose()
    {
        _animation.SadAnimation();
        _losePanel.SetActive(true);
        _basket.SetActive(false);
    }
}