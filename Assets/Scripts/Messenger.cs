using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Messenger : MonoBehaviour
{
    private TextMeshProUGUI message; // ссылка на текст
    private static Coroutine RunMessage; // ссылка на запущенную корутину

    [SerializeField] private string startMessageText;
    private void Start()
    {
        // берем компонент текста, т.к. текст и скрипт находятся на одном объекте
        message = GetComponent<TextMeshProUGUI>();
        WriteMessage(startMessageText); // напишите сюда первое сообщение для пользователя
    }
 
    public void WriteMessage(string text) // метод для запуска корутины с выводом сообщения
    {
        // проверка и остановка корутины, если она уже была запущена
        if (RunMessage != null) StopCoroutine(RunMessage);
        Debug.Log(message); 
        this.message.text = ""; // очистка строки
        // запуск корутины с выводом нового сообщения
        RunMessage = StartCoroutine(Message(text));
    }
 
    private IEnumerator Message(string message) // корутина для вывода сообщений
    {
        this.message.text = message; // записываем сообщение
        yield return new WaitForSeconds(4f); // ждем 4 секунды
        this.message.text = ""; // очищаем строку
    }

}