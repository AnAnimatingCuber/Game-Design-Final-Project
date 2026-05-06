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

        if (square.position.y < 739)
        {

            Vector2 moveVector = new Vector2(0f, 225.78125f);
            square.MovePosition(square.position + moveVector * 1);

        }

    }

    public void Right(InputAction.CallbackContext context)
    {

        if (square.position.x < 1559)
        {
            Vector2 moveVector = new Vector2(225.78125f, 0f);
            square.MovePosition(square.position + moveVector * 1);

        }

    }

    public void Down(InputAction.CallbackContext context)
    {

        if (square.position.y > 341)
        {

            Vector2 moveVector = new Vector2(0f, -225.78125f);
            square.MovePosition(square.position + moveVector * 1);

        }

    }

    public void Left(InputAction.CallbackContext context)
    {

        if (square.position.x > 361)
        {

            Vector2 moveVector = new Vector2(-225.78125f, 0f);
            square.MovePosition(square.position + moveVector * 1);

        }

    }

    void Update()
    {

       Debug.Log(square.position); 
        
    }

}
