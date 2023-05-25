using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoneTrigger : MonoBehaviour
{

    private int Score;

   public void OnTriggerEnter2D(Collider2D collision)
    {
        // Destruir el objeto que colisionó con la zona
        Destroy(collision.gameObject);
    }

    public void Reiniciar()
    {
        Score = 0;
    }
}

