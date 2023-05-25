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
    
    private void Start() {
        
        player = GameObject.FindGameObjectWithTag("Player");
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

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.Pickaxe && blockType == BlockType.BlockS)
            {
                // Lógica para romper el bloque con el pico
                Debug.Log("¡Has roto el bloque con el pico!");

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.ElectricDrill && blockType == BlockType.BlockD)
            {
                // Lógica para romper el bloque con el martillo eléctrico
                Debug.Log("¡Has roto el bloque con el martillo eléctrico!");

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.Axe && blockType == BlockType.BlockQ)
            {
                 // Lógica para romper el bloque con el hacha
                Debug.Log("Has roto el bloque con el hacha");

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.Hammer && blockType == BlockType.BlockW)
            {
                // Lógica para romper el bloque con el martillo
                Debug.Log("¡Has roto el bloque con el martillo!");

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.Dinamite && blockType == BlockType.BlockE)
            {
                // Lógica para romper el bloque con el dinamites
                Debug.Log("¡Has roto el bloque con el dinamites!");
                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else
            {
                // Lógica para indicar al jugador que seleccionó la herramienta incorrecta
                Debug.Log("Selecciona la herramienta correcta para romper este bloque.");
                
                // Bloquear el movimiento del jugador por un segundo
                PlayerController playerController = FindObjectOfType<PlayerController>();
                playerController.LockMovementForDuration(2f);
            }
        }
    }
}