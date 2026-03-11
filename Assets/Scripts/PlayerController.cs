using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{ 

    public float speed = 5f;
    public bool isSprinting;
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

    void Update()
    { 

        Vector2 moveVector = new Vector2(moveInput.x, moveInput.y);
        character.Move(moveVector * speed *Time.deltaTime);

    }

}