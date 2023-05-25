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
        score += multiplier * powerUpMultiplier;
        UpdateScoreDisplay();
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
