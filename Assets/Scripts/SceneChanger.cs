using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void OpenNewScene(int sceneIndex) // метод для смены сцены
    {
        StartCoroutine(AsyncLoad(sceneIndex)); // запускаем асинхронную загрузку сцены
    }

    private IEnumerator AsyncLoad(int index)
    {
        AsyncOperation ready = null;
        ready = SceneManager.LoadSceneAsync(index);
        while (!ready.isDone) // пока сцена не загрузилась
        {
            yield return null; // ждём следующий кадр
        }
    }
}