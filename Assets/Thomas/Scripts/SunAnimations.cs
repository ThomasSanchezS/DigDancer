using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunAnimations : MonoBehaviour
{
    [SerializeField] private float duration = 2;
    public Transform tittleImage;
    
    public void OnEnable() {
        transform.DOMove(new Vector2(450, 350), duration).OnComplete(()=> {tittleImage.transform.DOScale(new Vector2(25,40), duration);});
    }

    void OnDisable()
    {
        StopDeformations();
        ResetDeformations();
    }

    void StopDeformations()
    {
        
        DOTween.Kill(transform);
    }

    void ResetDeformations()
    {
        transform.DOMove(new Vector2(-450, -350), duration);
        transform.DOKill();
    }
}
