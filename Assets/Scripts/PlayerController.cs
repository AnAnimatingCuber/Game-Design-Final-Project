using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{ 

    public float speed = 3.5f;
    public bool isSprinting = false;
    public bool invOpen = false;
    public GameObject inventoryCanvas;
    public GameObject gameplayCanvas;
    public GameObject startCanvas;
    public GameObject pauseCanvas;
    private Rigidbody2D character;
    private Animator animator;
    private Vector2 moveInput;

    void Start()
    { 
    
        character = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    public void OnMove(InputAction.CallbackContext context)
    { 
    
        moveInput = context.ReadValue<Vector2>();
        if(moveInput.x != 0 || moveInput.y != 0)
        {

            animator.SetFloat("X", moveInput.x);
            animator.SetFloat("Y", moveInput.y);
            animator.SetBool("Walking", true);

        }
        else
        {

            animator.SetBool("Walking", false);

        }

    }

    public void Sprint(InputAction.CallbackContext context)
    {

        isSprinting = context.started || context.performed;
        if (isSprinting == true)
        {

            speed = 8.5f;

        }

        else if (isSprinting == false)
        {

            speed = 3.5f;

        }

    }

    public void inventory(InputAction.CallbackContext context)
    {

        if (invOpen == false)
        {

            gameplayCanvas.SetActive(false);
            inventoryCanvas.SetActive(true);
            invOpen = true;

        }

        else if (invOpen == true)
        {

            inventoryCanvas.SetActive(false);
            gameplayCanvas.SetActive(true);
            invOpen = false;

        }

    }

    void FixedUpdate()
    { 

        Vector2 moveVector = new Vector2(moveInput.x, moveInput.y);
        character.MovePosition(character.position + moveVector * speed * Time.fixedDeltaTime);

    }

}