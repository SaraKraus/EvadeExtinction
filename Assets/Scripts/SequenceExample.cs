using UnityEngine;
using DG.Tweening;

public class SequenceExample : MonoBehaviour
{
   void Start ()
   {
    Sequence seq = DOTween.Sequence();

    seq.Append(transform.DOMoveX(3,1f));
    seq.Append(transform.DOMoveY(2,1f));
    seq.Append(transform.DOMoveZ(2,.5f));
   }

   void Update()
   {

   }
}
