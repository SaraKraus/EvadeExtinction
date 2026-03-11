using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void NextLevel()
   {
     int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextIndex < SceneManager.sceneCountInBuildSettings)
     {
            SceneManager.LoadSceneAsync(nextIndex);
        }
        else
     {
            Debug.Log("No More Levels!");
     }

        //SceneManager.LoadScene/*Async*/(1);

   }

   /*public void LoadScene(string sceneName)
   {
    SceneManager.LoadSceneAsync(sceneName);
   }*/
}
