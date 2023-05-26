// BreakableBlock.cs
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public enum BlockType
    {
        BlockA,
        BlockS,
        BlockD,
        BlockQ,
        BlockW,
        BlockE
    }
    private GameObject player;
    public BlockType blockType;
    public float reach = 2f;

    private ScoreManager scoreManager;
    //private TimeManager timeManager;
    private int powerUpMultiplier = 1;

    private void Start() {
        
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = FindObjectOfType<ScoreManager>();
        //timeManager = FindObjectOfType<TimeManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Vector2.Distance(player.transform.position, transform.position) >= reach){
                return;
            }
            ToolManager toolManager = FindObjectOfType<ToolManager>();

            if (toolManager.selectedTool == ToolType.Shovel && blockType == BlockType.BlockA)
            {
                // Lógica para romper el bloque con la pala
                Debug.Log("¡Has roto el bloque con la pala!");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Pickaxe && blockType == BlockType.BlockS)
            {
                // Lógica para romper el bloque con el pico
                Debug.Log("¡Has roto el bloque con el pico!");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.ElectricDrill && blockType == BlockType.BlockD)
            {
                // Lógica para romper el bloque con el martillo eléctrico
                Debug.Log("¡Has roto el bloque con el martillo eléctrico!");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Axe && blockType == BlockType.BlockQ)
            {
                 // Lógica para romper el bloque con el hacha
                Debug.Log("Has roto el bloque con el hacha");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Hammer && blockType == BlockType.BlockW)
            {
                // Lógica para romper el bloque con el martillo
                Debug.Log("¡Has roto el bloque con el martillo!");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Dinamite && blockType == BlockType.BlockE)
            {
                // Lógica para romper el bloque con el dinamites
                Debug.Log("¡Has roto el bloque con el dinamites!");

                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else
            {
                // Lógica para indicar al jugador que seleccionó la herramienta incorrecta
                Debug.Log("Selecciona la herramienta correcta para romper este bloque.");

                // Restablecer combos
                scoreManager.ResetScore();
                if (powerUpMultiplier > 1)
                {
                    powerUpMultiplier = 1;
                    scoreManager.ApplyMultiplier(powerUpMultiplier);
                }

                // Bloquear el movimiento del jugador por un segundo
                PlayerController playerController = FindObjectOfType<PlayerController>();
                playerController.LockMovementForDuration(1f);
            }
        }
    }
}