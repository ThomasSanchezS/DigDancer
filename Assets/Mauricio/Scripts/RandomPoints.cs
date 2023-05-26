using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// El item de tiempo aparece cada multiplo de 10
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
            // Detectar si se suelta la tecla Espacio
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                // Vincular nuevamente el objeto generado como hijo del jugador
                spawnedObject.transform.SetParent(player.transform);

                // Ajustar la posición local del objeto generado
                Vector3 localPosition = spawnedObject.transform.localPosition;
                localPosition.y += yOffset;
                spawnedObject.transform.localPosition = localPosition;
            }
        }
    }
}

// Variante del item de tiempo apareciendo cada multiplo de 10 - NO FUNCIONA XD
/*public class RandomPoints : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del objeto a generar
    public Transform spawnPosition; // Posición de generación
    public GameObject player; // Objeto del personaje

    private int pointsThreshold = 10; // Umbral de puntos para generar el objeto
    private float yOffset = 2f; // Desplazamiento en el eje Y

    private GameObject spawnedObject; // Referencia al objeto generado
    private bool isObjectAttached = false; // Indicador de si el objeto está adjunto al jugador

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
                AttachObjectToPlayer();
            }
        }
    }

    private void Update()
    {
        if (spawnedObject != null && isObjectAttached)
        {
            // Detectar si se presiona la tecla Espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Desvincular el objeto generado del jugador
                DetachObjectFromPlayer();
            }
        }
        else if (spawnedObject != null && !isObjectAttached)
        {
            // Detectar si se suelta la tecla Espacio
            if (Input.GetKeyUp(KeyCode.Space))
            {
                // Vincular nuevamente el objeto generado como hijo del jugador
                AttachObjectToPlayer();
            }
        }
    }

    private void AttachObjectToPlayer()
    {
        spawnedObject.transform.SetParent(player.transform);

        // Ajustar la posición local del objeto generado
        Vector3 localPosition = spawnedObject.transform.localPosition;
        localPosition.y += yOffset;
        spawnedObject.transform.localPosition = localPosition;

        isObjectAttached = true;
    }

    private void DetachObjectFromPlayer()
    {
        spawnedObject.transform.SetParent(null);
        isObjectAttached = false;
    }
}*/

// El item de tiempo aparece cada x segundos
/*public class RandomPoints : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del objeto a generar
    public Transform spawnPosition; // Posición de generación
    public GameObject player; // Objeto del personaje

    private float generationInterval = 10f; // Intervalo de generación en segundos
    private float yOffset = 2f; // Desplazamiento en el eje Y

    private float timer = 0f; // Temporizador para el intervalo de generación
    private GameObject spawnedObject; // Referencia al objeto generado

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= generationInterval)
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

                // Reiniciar el temporizador
                timer = 0f;
            }
        }

        // Detectar si se presiona la tecla Espacio para desvincular el objeto generado del jugador
        if (spawnedObject != null && Input.GetKeyDown(KeyCode.Space))
        {
            spawnedObject.transform.SetParent(null);
            spawnedObject = null;
        }
    }
}*/

//El item de tiempo aparece cada "Combo x6" y cada x segundos mientras se siga en el "Combo x6" - NO FUNCIONA XD
/*public class RandomPoints : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del objeto a generar
    public Transform spawnPosition; // Posición de generación
    public GameObject player; // Objeto del personaje

    private int comboThreshold = 6; // Umbral de combo para generar el objeto
    private float yOffset = 2f; // Desplazamiento en el eje Y

    private float timer = 0f; // Temporizador para controlar el tiempo entre apariciones
    private float spawnInterval = 10f; // Intervalo de tiempo entre apariciones en segundos

    private void Start()
    {
        // Suscribirse al evento OnScoreChanged del ScoreManager
        ScoreManager.OnScoreChanged += CheckCombo;
    }

    private void CheckCombo(int score)
    {
        if (score % comboThreshold == 0)
        {
            // Generar una instancia del objeto en la posición establecida
            GameObject spawnedObject = Instantiate(itemPrefab, spawnPosition.position, Quaternion.identity);

            // Establecer el objeto generado como hijo del personaje
            spawnedObject.transform.SetParent(player.transform);

            // Ajustar la posición local del objeto generado
            Vector3 localPosition = spawnedObject.transform.localPosition;
            localPosition.y += yOffset;
            spawnedObject.transform.localPosition = localPosition;

            // Desuscribirse del evento después de generar el objeto
            ScoreManager.OnScoreChanged -= CheckCombo;
        }
    }

    private void Update()
    {
        // Incrementar el temporizador
        timer += Time.deltaTime;

        // Verificar si ha pasado el tiempo suficiente para generar el objeto
        if (timer >= spawnInterval)
        {
            // Generar una instancia del objeto en la posición establecida
            GameObject spawnedObject = Instantiate(itemPrefab, spawnPosition.position, Quaternion.identity);

            // Ajustar la posición local del objeto generado
            Vector3 localPosition = spawnedObject.transform.localPosition;
            localPosition.y += yOffset;
            spawnedObject.transform.localPosition = localPosition;

            // Reiniciar el temporizador
            timer = 0f;
        }
    }
}*/