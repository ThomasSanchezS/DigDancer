using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationScore : MonoBehaviour
{
    public float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector2(800, 550), duration);
    }
}
