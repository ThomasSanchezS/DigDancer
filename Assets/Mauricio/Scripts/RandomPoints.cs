using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// El item de tiempo aparece cada multiplo de 10 score
/*public class RandomPoints : MonoBehaviour
{
    public GameObject itemPrefab; // Prefab del objeto a generar
    public Transform spawnPosition; // Posición de generación
    public GameObject player; // Objeto del personaje

    private int pointsThreshold = 50; // Umbral de puntos para generar el objeto
    private float yOffset = 2f; // Desplazamiento en el eje Y
    private float despawnDelay = 5f; // Tiempo de espera para despawn

    private GameObject spawnedObject; // Referencia al objeto generado

    private void Start()
    {
        // Suscribirse al evento OnScoreChanged del ScoreManager
        ScoreManager.OnScoreChanged += CheckScore;
    }

    private void CheckScore(int score)
    {
        if(score % pointsThreshold == 0 && spawnedObject == null)
        {
            // Generar una instancia del objeto en la posición establecida
            spawnedObject = Instantiate(itemPrefab, spawnPosition.position, Quaternion.identity);

            // Establecer el objeto generado como hijo del jugador
            spawnedObject.transform.SetParent(player.transform);

            // Ajustar la posición local del objeto generado
            Vector3 localPosition = spawnedObject.transform.localPosition;
            localPosition.y += yOffset;
            spawnedObject.transform.localPosition = localPosition;

            // Iniciar la coroutine para despawn después del tiempo especificado
            StartCoroutine(DelayedDespawn());
        }
    }

    private IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(despawnDelay);

        if (spawnedObject != null)
        {
            // Desvincular el objeto generado del jugador
            spawnedObject.transform.SetParent(null);
            Destroy(spawnedObject);
            spawnedObject = null;
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
}*/

// El item de tiempo aparece cada multiplo de x6

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

    private float yOffset = .25f; // Desplazamiento en el eje Y
    private float despawnDelay = 5f; // Tiempo de espera para despawn
    private float generateInterval = 20f; // Intervalo de generación después de alcanzar combo x6

    private GameObject spawnedObject; // Referencia al objeto generado
    private bool generateEnabled = true; // Indicador de si la generación está habilitada
    private bool combo4Generated = false; // Indicador de si el objeto combo 4 ya ha sido generado
    private bool combo8Generated = false; // Indicador de si el objeto combo 8 ya ha sido generado
    private bool combo12Generated = false; // Indicador de si el objeto combo 6 ya ha sido generado


    private void Update()
    {
        int currentCombo = ScoreManager.Instance.GetCurrentCombo();

        if (currentCombo == 0)
        {
            combo4Generated = false;
            combo8Generated = false;
        }
        if (currentCombo == 4 && !combo4Generated)
        {
            GenerateObject();
            combo4Generated = true;
        }
        else if (currentCombo == 8 && !combo8Generated)
        {
            GenerateObject();
            combo8Generated = true;
        }
        else if (currentCombo == 12 && !combo12Generated)
        {
            GenerateObject();
            combo12Generated = true;
            StartCoroutine(GenerateObjectPeriodically());
        }

        if (spawnedObject != null)
        {
            // Detectar si se presiona la tecla Espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Pausar el salto y el parpadeo utilizando DOTween
                spawnedObject.transform.DOPause();
                spawnedObject.GetComponent<Renderer>().material.DOPause();

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

                // Calcular la posición de destino para el salto
                float jumpHeight = 2f;
                Vector3 jumpDestination = spawnedObject.transform.localPosition + new Vector3(0f, jumpHeight, 0f);

                // Aplicar el movimiento hacia arriba y abajo utilizando DOTween
                float jumpDuration = 2f;
                spawnedObject.transform.DOLocalJump(jumpDestination, jumpHeight, 1, jumpDuration).SetLoops(-1, LoopType.Yoyo);

                // Iniciar el parpadeo utilizando DOTween
                Color originalColor = spawnedObject.GetComponent<Renderer>().material.color;
                Color blinkingColor = Color.red; // Color parpadeante
                float blinkingDuration = 0.5f;
                spawnedObject.GetComponent<Renderer>().material.DOBlendableColor(blinkingColor, blinkingDuration).SetLoops(-1, LoopType.Yoyo);
            }
        }
    }

    private void GenerateObject()
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

            // Iniciar la coroutine para despawn después del tiempo especificado
            StartCoroutine(DelayedDespawn());
        }
    }

    private IEnumerator DelayedDespawn()
    {
        yield return new WaitForSeconds(despawnDelay);

        if (spawnedObject != null)
        {
            spawnedObject.transform.DOKill();
            spawnedObject.GetComponent<Renderer>().material.DOKill();

            // Desvincular el objeto generado del jugador
            spawnedObject.transform.SetParent(null);
            Destroy(spawnedObject);
            spawnedObject = null;

            if (ScoreManager.Instance.GetCurrentCombo() >= 12)
            {
                generateEnabled = false;
                yield return new WaitForSeconds(generateInterval);
                generateEnabled = true;
            }
        }
    }

    private IEnumerator GenerateObjectPeriodically()
    {
        while (generateEnabled)
        {
            yield return new WaitForSeconds(generateInterval);
            GenerateObject();
        }
    }
}*/

// El item aparece en un rango de tiempo
public class RandomPoints : MonoBehaviour
{
    private float minSpawn = 10f, maxSpawn = 30f;
    private float despawnDelay = 2f;
    public GameObject itemPrefab;
    public Transform spawnPosition;
    public GameObject player;

    private float yOffset = .25f; // Desplazamiento en el eje Y
    private GameObject spawnedObject; // Referencia al objeto generado
    private bool generateEnabled = true; // Indicador de si la generación está habilitada
    private bool objectTaken = false; // Variable para controlar si el objeto ha sido tomado

    private void Update()
    {
        if (spawnedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Desvincular el objeto generado del jugador
                spawnedObject.transform.SetParent(null);
                spawnedObject = null;
                objectTaken = false; // Marcar el objeto como tomado
            }
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

        if (!objectTaken)
        {
            StartCoroutine(SpawnTime());
            objectTaken = true; // Restablecer la variable de objeto tomado
        }
    }

    IEnumerator SpawnTime()
    {
        yield return new WaitForSeconds(Random.Range(minSpawn, maxSpawn));
        GenerateObject();
    }

    private IEnumerator DespawnTime()
    {
        yield return new WaitForSeconds(despawnDelay);

        if (spawnedObject != null)
        {
            // Desvincular el objeto generado del jugador
            spawnedObject.transform.SetParent(null);
            Destroy(spawnedObject);
            spawnedObject = null;
        }
    }

    private void GenerateObject()
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

            // Iniciar la coroutine para despawn después del tiempo especificado
            StartCoroutine(DespawnTime());
        }
    }
}
