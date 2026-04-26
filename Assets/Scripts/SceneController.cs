using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
       //StartCoroutine(LoadLevel());
   }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public IEnumerator LoadLevel()
   {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(5);
        transitionAnim.SetTrigger("Start");
   }
}






    // transitionAnim.SetTrigger("End");
    // yield return new WaitForSeconds(1);
    // int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
    // transitionAnim.SetTrigger("Start");

    //     if(nextIndex < SceneManager.sceneCountInBuildSettings)
    // {
    //         SceneManager.LoadSceneAsync(nextIndex);
    // }
    //     //SceneManager.LoadScene/*Async*/(1);


   /*public void LoadScene(string sceneName)
   {
    SceneManager.LoadSceneAsync(sceneName);
   }*/

