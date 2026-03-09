using UnityEngine;
using DG.Tweening;

public class JumpExample : MonoBehaviour
{
    void Start()
    {
        transform.DOJump(new Vector3(-0.36305f, -2.31746f), .5f, 3, 3f);
    }

    void Update()
    {

    }
}
