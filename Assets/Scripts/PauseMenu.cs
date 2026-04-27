using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // [SerializeField] GameObject pauseMenu;
    [SerializeField] CanvasGroup pauseMenu;
    [SerializeField] Button pauseButton;

    void Awake()
    {
        
    }

     public void Pause()
     {
        pauseMenu.alpha = 0;
        pauseMenu.gameObject.SetActive(true);
        pauseMenu.DOFade(1f, 0.3f).SetUpdate(true);
        pauseMenu.interactable = true;
        pauseMenu.blocksRaycasts = true;
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
     }

    public void Quit()
      {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
     }

    public void Resume()
      {
        pauseMenu.DOFade(0f, 0.3f).SetUpdate(true).OnComplete(() => { pauseMenu.gameObject.SetActive(false); pauseButton.gameObject.SetActive(true);});
        pauseMenu.interactable = false;
        pauseMenu.blocksRaycasts = false;

        Time.timeScale = 1;
      }

     public void Restart()
       {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
      }
}
