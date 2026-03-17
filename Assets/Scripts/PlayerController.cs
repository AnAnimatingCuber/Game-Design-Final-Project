using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{ 

    public float speed = 5f;
    public bool isSprinting;
    public bool invOpen = false;
    public GameObject inventoryCanvas;
    public GameObject gameplayCanvas;
    public GameObject startCanvas;
    public GameObject pauseCanvas;
    private CharacterController character;
    private Vector2 moveInput;

    void Start()
    { 
    
        character = gameObject.GetComponent<CharacterController>();

    }

    public void OnMove(InputAction.CallbackContext context)
    { 
    
        moveInput = context.ReadValue<Vector2>();


    }

    public void Sprint(InputAction.CallbackContext context)
    {

        isSprinting = context.started || context.performed;
        if (isSprinting == true)
        {

            speed = 10f;

        }

        else if (isSprinting == false)
        {

            speed = 5f;

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

    void Update()
    { 

        Vector2 moveVector = new Vector2(moveInput.x, moveInput.y);
        character.Move(moveVector * speed *Time.deltaTime);

    }

}