using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Level Complete!");
            SceneController.instance.LoadMenu();
            //SceneManager.LoadScene/*Async*/(1);
        }
    }

}
