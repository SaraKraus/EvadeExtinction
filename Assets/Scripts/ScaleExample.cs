using UnityEngine;
using DG.Tweening;

public class ScaleExample : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(1.5f, .3f).SetLoops(8, LoopType.Yoyo);
    }

    void Update()
    {

    }
}
