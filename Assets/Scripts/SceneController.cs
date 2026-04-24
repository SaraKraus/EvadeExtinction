using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    // private void Awake()
    // {
    //     if(instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // public void LoadMenu()
    // {
    //     SceneManager.LoadScene(0);
    // }
    
   public void NextLevel()
   {
    StartCoroutine(LoadLevel());
   }

  public IEnumerator LoadLevel()
   {
    transitionAnim.SetTrigger("End");
    yield return new WaitForSeconds(5);
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
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

