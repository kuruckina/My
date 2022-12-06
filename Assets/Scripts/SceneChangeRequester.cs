using UnityEngine;

public class SceneChangeRequester : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void RequestSceneChange()
    {
        MainManager.sceneChanger.OpenNewScene(sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}