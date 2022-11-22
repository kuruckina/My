using UnityEngine;

public class PauseManager : MonoBehaviour
{
   [SerializeField] private GameObject _pause;
   private bool _isPaused;
   
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         TogglePause();
         _pause.SetActive(_isPaused);
      }
   }

   private void TogglePause()
   {
      _isPaused = !_isPaused;
      Time.timeScale = _isPaused ? 0 : 1;
   }
}