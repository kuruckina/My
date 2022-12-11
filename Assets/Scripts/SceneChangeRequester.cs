using UnityEngine;

public class SceneChangeRequester : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void RequestSceneChange()
    {
        InventoryManager.item = 0;
        MainManager.sceneChanger.OpenNewScene(sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}