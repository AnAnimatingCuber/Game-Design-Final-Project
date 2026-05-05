using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryScript : MonoBehaviour
{

    private Rigidbody2D square;
    void Start()
    {

        square = GetComponent<Rigidbody2D>();

    }
    
    public void Up(InputAction.CallbackContext context)
    {

        Vector2 moveVector = new Vector2(0f, 225.78125f);
        Debug.Log(moveVector);
        square.MovePosition(square.position + moveVector * 1);

    }

    public void Right(InputAction.CallbackContext context)
    {

        Vector2 moveVector = new Vector2(225.78125f, 0f);
        Debug.Log(moveVector);
        square.MovePosition(square.position + moveVector * 1);

    }

    public void Down(InputAction.CallbackContext context)
    {

        Vector2 moveVector = new Vector2(0f, -225.78125f);
        Debug.Log(moveVector);
        square.MovePosition(square.position + moveVector * 1);

    }

    public void Left(InputAction.CallbackContext context)
    {

        Vector2 moveVector = new Vector2(-225.78125f, 0f);
        Debug.Log(moveVector);
        square.MovePosition(square.position + moveVector * 1);

    }

    void Update()
    {

        
        
    }

}
