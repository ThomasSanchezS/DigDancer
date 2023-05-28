using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSystem : MonoBehaviour
{
    public GameObject[] elements; // Array con los elementos a seleccionar
    public Transform center; // Posici�n central del carrusel
    public float spacing = 2f; // Espaciado entre elementos
    public float rotationSpeed = 200f; // Velocidad de rotaci�n del carrusel

    private int currentIndex = 0; // �ndice del elemento seleccionado actualmente

    private void Start()
    {
        // Posicionar los elementos inicialmente
        PositionElements();
    }

    private void Update()
    {
        // Girar el carrusel continuamente
        RotateCarousel();

        // Detectar la entrada del usuario para cambiar la selecci�n
        if (Input.GetKeyDown(KeyCode.A))
        {
            SelectElementByIndex(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SelectElementByIndex(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SelectElementByIndex(2);
        }
    }

    private void RotateCarousel()
    {
        // Rotar el carrusel alrededor del centro
        transform.RotateAround(center.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void PositionElements()
    {
        int numElements = elements.Length;
        float angleStep = 360f / numElements;
        float currentAngle = 0f;

        for (int i = 0; i < numElements; i++)
        {
            // Calcular la posici�n del elemento en el c�rculo
            float angle = currentAngle * Mathf.Deg2Rad;
            Vector3 position = center.position + new Vector3(Mathf.Sin(angle), 0f, Mathf.Cos(angle)) * spacing;

            // Asignar la posici�n al elemento
            elements[i].transform.position = position;

            // Ajustar la escala del elemento seg�n su distancia al centro
            float scale = Mathf.Clamp01(1f - Mathf.Abs(currentAngle) / 180f);
            elements[i].transform.localScale = Vector3.one * scale;

            // Actualizar el �ngulo para el siguiente elemento
            currentAngle += angleStep;
        }
    }

    private void SelectElementByIndex(int index)
    {
        // Asegurarse de que el �ndice est� dentro del rango del array
        if (index >= 0 && index < elements.Length)
        {
            // Actualizar el �ndice actual
            currentIndex = index;

            // Actualizar la visualizaci�n de los elementos
            UpdateElementDisplay();
        }
    }

    private void UpdateElementDisplay()
    {
        int numElements = elements.Length;

        // Actualizar el estado de visibilidad de cada elemento
        for (int i = 0; i < numElements; i++)
        {
            bool isSelected = i == currentIndex;
            elements[i].SetActive(isSelected);
        }
    }
}

