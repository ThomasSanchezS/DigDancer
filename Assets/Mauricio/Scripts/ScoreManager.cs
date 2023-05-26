using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int combo = 0;
    private int multiplier = 1;
    public TextMeshProUGUI scoreT;
    public TextMeshProUGUI comboT;

    public delegate void ScoreChanged(int score);
    public static event ScoreChanged OnScoreChanged;

    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get { return instance; }
    }

    public int GetCombo()
    {
        return combo;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (combo == 4)
        {
            multiplier = 2;
            comboT.text = "Combo x" + multiplier.ToString();
        }
        else if (combo == 8)
        {
            multiplier = 4;
            comboT.text = "Combo x" + multiplier.ToString();
        }
        else if (combo >= 12)
        {
            multiplier = 6;
            comboT.text = "Combo x" + multiplier.ToString();
        }
        else
        {
            comboT.text = " ";
        }
    }

    public void IncreaseScore(int powerUpMultiplier)
    {
        combo++;
        Debug.Log("El combo es: " + combo);
        score += multiplier * powerUpMultiplier;
        UpdateScoreDisplay();

        if (OnScoreChanged != null)
        {
            OnScoreChanged(score);
        }
    }

    public void ResetScore()
    {
        //score = 0;
        multiplier = 1;
        combo = 0;
        UpdateScoreDisplay();
    }

    public void ApplyMultiplier(int powerUpMultiplier)
    {
        multiplier *= powerUpMultiplier;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreT.text = "Score: " + score.ToString();
    }
}
