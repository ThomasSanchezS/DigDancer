using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private ScoreManager scoreManager;
    private TimeManager timeManager;

    private int powerUpMultiplier = 1;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.IncreaseScore(powerUpMultiplier);
            timeManager.IncreaseTime();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Miss"))
        {
            scoreManager.ResetScore();
            if (powerUpMultiplier > 1)
            {
                powerUpMultiplier = 1;
                scoreManager.ApplyMultiplier(powerUpMultiplier);
            }
            Destroy(gameObject);
        }
    }
}

