using UnityEngine;
using DG.Tweening;

public class moveExample : MonoBehaviour
{
    void Start()
    {
        transform.DOMove(new Vector3(5,2,0), 1.5f).SetEase(Ease.OutBounce);
    }
    void Update()
    {

    }
}
