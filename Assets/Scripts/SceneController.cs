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
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    
   public void NextLevel()
   {
     int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextIndex < SceneManager.sceneCountInBuildSettings)
    {
            SceneManager.LoadSceneAsync(nextIndex);
    }
        //SceneManager.LoadScene/*Async*/(1);

   }

   /*public void LoadScene(string sceneName)
   {
    SceneManager.LoadSceneAsync(sceneName);
   }*/
}
