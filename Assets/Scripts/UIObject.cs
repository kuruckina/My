using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    public GameObject objectInScene;
    [SerializeField] private Image imagePlace;
    [SerializeField] private Sprite image;
    [SerializeField] private Sprite red;
    [SerializeField] private Sprite green;

    private Image borderPlace;
    public bool State { get; set; } // автоматич свойство состояние подобран/не подобран объект

    private void OnEnable()
    {
        borderPlace = gameObject.GetComponent<Image>();
    }

    public void UpdateImage()
    {
        if (State)
        {
            imagePlace.sprite = image;
            borderPlace.sprite = green;
        }
        else
        {
            imagePlace.sprite = image;
            borderPlace.sprite = red;
        }
    }

    public GameObject myObject()
    {
        return objectInScene;
    }
}