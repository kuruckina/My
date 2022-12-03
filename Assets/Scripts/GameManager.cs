using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Coroutine end;
    public static bool _win = false;

    public void WinGame()
    {
        if (end == null)
        {
            _win = true;
            Debug.Log("WIN");
            InventoryManager.item = 0;
            end = StartCoroutine(BeforeExit());
        }
    }

    public void LoseGame()
    {
        if (end == null)
        {
            Debug.Log("Lose");
            InventoryManager.item = 0;
            end = StartCoroutine(BeforeExit());
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator BeforeExit()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadSceneAsync(3);
    }
}