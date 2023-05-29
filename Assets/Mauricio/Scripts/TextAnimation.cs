using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ComboText;
    public TextMeshProUGUI TimeText;
    public float movementDistance = 10f; // Distancia de movimiento en unidades del mundo
    public float movementDuration = 0.5f; // Duración de la animación de movimiento en segundos
    public float colorChangeDuration = 1f; // Duración de cada transición de color en segundos
    public Color[] colorPalette; // Paleta de colores para el cambio de color
    //public float shakeDuration = 0.5f; // Duración de la sacudida en segundos
    //public float shakeStrength = 1f; // Intensidad de la sacudida

    private void Start()
    {
        // Configurar la animación de movimiento utilizando DOTween
        ScoreText.rectTransform.DOMoveY(ScoreText.rectTransform.position.y - movementDistance, movementDuration)
        .SetEase(Ease.InOutSine)
        .SetLoops(-1, LoopType.Yoyo);

        ComboText.transform.localScale = Vector3.zero;
        ComboText.transform.DOScale(Vector3.one, 0.2f).SetDelay(0.5f);
        ComboText.transform.DOScale(Vector3.zero, 0.2f).SetDelay(1f);

        TimeText.DOFade(0f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetDelay(1f);
    }
}
