using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{ 

    public float speed = 3.5f;
    public bool isSprinting = false;
    public bool invOpen = false;
    public bool pickUpAllowed = false;
    public GameObject inventoryCanvas;
    public GameObject gameplayCanvas;
    public GameObject startCanvas;
    public GameObject pauseCanvas;
    public PickupScript Destroy;
    public string objtag;
    public int keys = 0;
    public int lanternPeices = 0;
    public List<string> inventory = new List<string>();
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

            speed = 6f;

        }

        else if (isSprinting == false)
        {

            speed = 3.5f;

        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        pickUpAllowed = true;
        if (other.gameObject.tag == "keyt")
        {

            Debug.Log("keyt");
            objtag = "kt";
            GameObject key_piece_top_0 = GameObject.Find("key_piece_top_0");
            Destroy = key_piece_top_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "keyb")
        {

            Debug.Log("keyb");
            objtag = "kb";
            GameObject key_piece_bottom_0 = GameObject.Find("key_piece_bottom_0");
            Destroy = key_piece_bottom_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanterna")
        {

            Debug.Log("lanterna");
            objtag = "la";
            GameObject lantern_piece_one_0 = GameObject.Find("lantern_piece_one_0");
            Destroy = lantern_piece_one_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternb")
        {

            Debug.Log("lanternb");
            objtag = "lb";
            GameObject lantern_piece_two_0 = GameObject.Find("lantern_piece_two_0");
            Destroy = lantern_piece_two_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternc")
        {

            Debug.Log("lanternc");
            objtag = "lc";
            GameObject lantern_piece_three_0 = GameObject.Find("lantern_piece_three_0");
            Destroy = lantern_piece_three_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternd")
        {

            Debug.Log("lanternd");
            objtag = "ld";
            GameObject lantern_piece_four_0 = GameObject.Find("lantern_piece_four_0");
            Destroy = lantern_piece_four_0.GetComponent<PickupScript>();

        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {

        pickUpAllowed = false;
        Debug.Log("Pickup Not Allowed");

    }

    public void Pickup(InputAction.CallbackContext context)
    {

        if (pickUpAllowed == true)
        {

            if (objtag == "kt")
            {

                keys = keys + 1;

            }

            else if (objtag == "kb")
            {

                keys = keys + 1;

            }

            else if (objtag == "la")
            {

                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "lb")
            {

                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "lc")
            {

                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "ld")
            {

                lanternPeices = lanternPeices + 1;

            }

            Destroy.Destroy();

        }

    }

    public void openInventory(InputAction.CallbackContext context)
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