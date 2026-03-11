using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Complete!");
            SceneController.instance.NextLevel();
            //SceneManager.LoadScene/*Async*/(1);
        }
    }

}
