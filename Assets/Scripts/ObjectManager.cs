using UnityEngine;
using TMPro;

public class ObjectManager : MonoBehaviour
{

   public static ObjectManager Instance /*{ get; private set; }*/;
    private int Objects = 0;
    //[SerializeField] private TMP_Text objectsDisplay;
    public TMP_Text objectsDisplay;

    private void Awake()
   {
       if(Instance == null)
       {
           Instance = this;
       }
       else
      {
           Destroy(gameObject);    
      }
      objectsDisplay.text = $"{Objects}";
   }

    // private void Start()
    // {
    //     OnGUI();
    // }
    public void ChangeObjects()
    {
        Objects++;
        OnGUI();
    }

    private void OnGUI()
    {
      //  objectsDisplay.text = Objects.ToString();

        if(objectsDisplay != null)
        {
            objectsDisplay.text = $"{Objects}";
        }
    }

    public void ResetObjects()
    {
        Objects = 0;
        OnGUI();
    }

}
