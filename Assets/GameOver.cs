using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI puntajeFinalText;

    private void Start()
    {
        int puntajeFinal = PlayerPrefs.GetInt("PuntajeFinal", 0);
        puntajeFinalText.text = "Tu puntaje final fue: " + puntajeFinal;
    }
}
