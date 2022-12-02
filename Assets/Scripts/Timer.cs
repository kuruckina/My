using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text; 
    private DateTime timer = new DateTime(1, 1, 1, 0, 1, 00);

    private void Start()
    {
        StartCoroutine(Timerenumerator());
    }

    private IEnumerator Timerenumerator()
    {
        while (true)
        {
            text.text = timer.Minute.ToString() + ":" + timer.Second.ToString(); 
            timer = timer.AddSeconds(-1); 

            if (timer.Second == 0 && timer.Minute == 0)
            {
                text.color = new Color(1, 0, 0); 
                text.text = "00 : 00";
                MainManager.game.LoseGame(); 
                break; 
            }

            yield return new WaitForSeconds(1); 
        }
    }
}