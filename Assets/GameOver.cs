using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private ScoreManager scoreManager;
    public TextMeshProUGUI puntajefinal;

    private void Start()
    { 
        scoreManager = FindObjectOfType<ScoreManager>();
        puntajefinal.text = "Tu puntaje final fue: " + scoreManager;
    }
}
