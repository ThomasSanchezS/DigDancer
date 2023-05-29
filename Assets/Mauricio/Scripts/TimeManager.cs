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

    private void Update()
    {
        time -= Time.deltaTime;
        timeT.text = "Time: " + time.ToString("f0");

        if (time < 0)
        {
            Debug.Log("Se acabo el tiempo");
            time = 0;
            SceneManager.LoadScene("Game Over");
        }
    }

    public void IncreaseTime()
    {
        time += extra;
    }
}

