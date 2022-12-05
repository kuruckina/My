using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public AudioSource _source;
    private DateTime timer = new DateTime(1, 1, 1, 0, 0, 10);

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
            if (timer.Second == 5)
            {
                text.color = new Color(1, 0, 0); 
                _source.Play();
            }

            if (timer.Second == 0 && timer.Minute == 0)
            {
                
                text.text = "0 : 0";
                MainManager.game.LoseGame(); 
                break; 
            }

            yield return new WaitForSeconds(1); 
        }
    }
}