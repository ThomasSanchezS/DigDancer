using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunAnimations : MonoBehaviour
{
    [SerializeField] private float duration = 2;
    public Transform tittleImage;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector2(450, 350), duration).OnComplete(()=> {tittleImage.transform.DOScale(new Vector2(25,40), duration);});
    }
}
