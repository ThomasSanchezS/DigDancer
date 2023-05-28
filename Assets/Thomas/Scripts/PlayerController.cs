// PlayerController.cs
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private ToolManager toolManager;
    private Rigidbody2D rb;
    private bool isMovementLocked = false;
    private float movementLockDuration = 0f;
    public Animator animate;

    public float jumpForce = 5f;
    public bool isGrounded = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        toolManager = FindObjectOfType<ToolManager>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isMovementLocked)
        {
            // Si el movimiento está bloqueado, esperar hasta que termine el tiempo de bloqueo
            movementLockDuration -= Time.deltaTime;
            if (movementLockDuration <= 0f)
            {
                isMovementLocked = false;
                animate.SetBool("isLocked", false);
            }
            else
            {
                return; // Salir del método Update mientras el movimiento está bloqueado
            }
        }

        // Detectar entrada para seleccionar herramienta
        if (Input.GetKeyDown(KeyCode.A))
        {
            toolManager.SelectTool(KeyCode.A);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            toolManager.SelectTool(KeyCode.S);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            toolManager.SelectTool(KeyCode.D);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            toolManager.SelectTool(KeyCode.Q);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            toolManager.SelectTool(KeyCode.W);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            toolManager.SelectTool(KeyCode.E);
        }

        // Detectar entrada para saltar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Detectar click derecho para romper bloque debajo del jugador
        /**if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 3f);

            if (hit.collider != null)
            {
                BreakableBlock block = hit.collider.GetComponent<BreakableBlock>();
                if (block != null)
                {
                    block.BreakBlock(toolManager.selectedTool);
                }
            }
        }**/
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        animate.SetTrigger("isJumping");
    }

    public void LockMovementForDuration(float duration)
    {
        isMovementLocked = true;
        animate.SetBool("isLocked", true);
        movementLockDuration = duration;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}