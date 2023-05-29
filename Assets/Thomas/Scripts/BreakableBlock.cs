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
    public Animator playerAnimator;

    public AudioSource AQ;
    public AudioSource SW;
    public AudioSource DE;

    private void Start() {
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponentInChildren<Animator>();
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
                AQ.Play();
                playerAnimator.SetTrigger("ToolA");
                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Pickaxe && blockType == BlockType.BlockS)
            {
                // Lógica para romper el bloque con el pico
                Debug.Log("¡Has roto el bloque con el pico!");
                SW.Play();
                playerAnimator.SetTrigger("ToolS");
                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.ElectricDrill && blockType == BlockType.BlockD)
            {
                // Lógica para romper el bloque con el martillo eléctrico
                Debug.Log("¡Has roto el bloque con el martillo eléctrico!");
                DE.Play();
                playerAnimator.SetTrigger("ToolD");
                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Axe && blockType == BlockType.BlockQ)
            {
                playerAnimator.SetTrigger("ToolA");
                 // Lógica para romper el bloque con el hacha
                Debug.Log("Has roto el bloque con el hacha");
                AQ.Play();
                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Hammer && blockType == BlockType.BlockW)
            {
                // Lógica para romper el bloque con el martillo
                playerAnimator.SetTrigger("ToolS");
                Debug.Log("¡Has roto el bloque con el martillo!");
                SW.Play();
                // Incrementar puntos
                scoreManager.IncreaseScore(powerUpMultiplier);

                // Eliminar el bloque u realizar cualquier otra acción deseada
                gameObject.SetActive(false);
            }
            else if (toolManager.selectedTool == ToolType.Dinamite && blockType == BlockType.BlockE)
            {
                // Lógica para romper el bloque con el dinamites
                Debug.Log("¡Has roto el bloque con el dinamites!");
                playerAnimator.SetTrigger("ToolD");
                DE.Play();
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