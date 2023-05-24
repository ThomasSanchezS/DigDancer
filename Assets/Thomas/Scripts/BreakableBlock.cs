// BreakableBlock.cs
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    public enum BlockType
    {
        BlockA,
        BlockB,
        BlockC
    }
    public Transform playerPos;
    public BlockType blockType;
    public float reach = 2f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Vector2.Distance(playerPos.position, transform.position) >= reach){
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
            else if (toolManager.selectedTool == ToolType.Pickaxe && blockType == BlockType.BlockB)
            {
                // Lógica para romper el bloque con el pico
                Debug.Log("¡Has roto el bloque con el pico!");

                // Eliminar el bloque u realizar cualquier otra acción deseada
                Destroy(gameObject);
            }
            else if (toolManager.selectedTool == ToolType.ElectricDrill && blockType == BlockType.BlockC)
            {
                // Lógica para romper el bloque con el martillo eléctrico
                Debug.Log("¡Has roto el bloque con el martillo eléctrico!");

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