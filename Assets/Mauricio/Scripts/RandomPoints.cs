using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del objeto a generar
    public Transform spawnPosition; // Posición de generación
    public GameObject player; // Objeto del personaje

    private int pointsThreshold = 10; // Umbral de puntos para generar el objeto
    private float yOffset = 2f; // Desplazamiento en el eje Y

    private GameObject spawnedObject; // Referencia al objeto generado

    private void Start()
    {
        // Suscribirse al evento OnScoreChanged del ScoreManager
        ScoreManager.OnScoreChanged += CheckScore;
    }

    private void CheckScore(int score)
    {
        if (score % pointsThreshold == 0)
        {
            if (spawnedObject == null)
            {
                // Generar una instancia del objeto en la posición establecida
                spawnedObject = Instantiate(itemPrefab, spawnPosition.position, Quaternion.identity);

                // Establecer el objeto generado como hijo del jugador
                spawnedObject.transform.SetParent(player.transform);

                // Ajustar la posición local del objeto generado
                Vector3 localPosition = spawnedObject.transform.localPosition;
                localPosition.y += yOffset;
                spawnedObject.transform.localPosition = localPosition;
            }
        }
    }

    private void Update()
    {
        if (spawnedObject != null)
        {
            // Detectar si se presiona la tecla Espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Desvincular el objeto generado del jugador
                spawnedObject.transform.SetParent(null);
                spawnedObject = null;
            }
        }
    }
}





