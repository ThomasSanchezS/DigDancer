using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    public GameObject Item; // Lista de objetos para generar

    public float spawnInterval = 1f; // Intervalo de generaci�n
    public Vector2 spawnPositionRange; // Rango de posici�n de generaci�n

    private void Start()
    {
        // Iniciar la generaci�n de objetos en intervalos regulares
        InvokeRepeating("SpawnRandomObject", spawnInterval, spawnInterval);
    }

    private void SpawnRandomObject()
    {
        // Calcular una posici�n aleatoria dentro del rango establecido
        float randomX = UnityEngine.Random.Range(spawnPositionRange.x, spawnPositionRange.y);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        // Instanciar el objeto seleccionado en la posici�n calculada
        Instantiate(Item, spawnPosition, Quaternion.identity);
    }
}