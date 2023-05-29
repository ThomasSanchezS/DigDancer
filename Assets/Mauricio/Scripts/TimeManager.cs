using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float time;
    public int extra;
    public TextMeshProUGUI timeT;
    private ScoreManager scoreManager;

    private void Update()
    {
        time -= Time.deltaTime;
        timeT.text = "Time: " + time.ToString("f0");

        if (time < 0)
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            int puntajeFinal = scoreManager.GetScore(); // Obtener el puntaje final desde el ScoreManager
            PlayerPrefs.SetInt("PuntajeFinal", puntajeFinal);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Game Over");
        }
    }

    public void IncreaseTime()
    {
        time += extra;
    }
}

