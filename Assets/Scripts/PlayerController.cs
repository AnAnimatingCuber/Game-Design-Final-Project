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
    public GameObject pauseCanvas;
    public PickupScript destroy;
    public string objtag;
    public int keys = 0;
    public int lanternPeices = 0;
    public string selectedObj;
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

        if (invOpen == false)
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
            destroy = key_piece_top_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "keyb")
        {

            Debug.Log("keyb");
            objtag = "kb";
            GameObject key_piece_bottom_0 = GameObject.Find("key_piece_bottom_0");
            destroy = key_piece_bottom_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanterna")
        {

            Debug.Log("lanterna");
            objtag = "la";
            GameObject lantern_piece_one_0 = GameObject.Find("lantern_piece_one_0");
            destroy = lantern_piece_one_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternb")
        {

            Debug.Log("lanternb");
            objtag = "lb";
            GameObject lantern_piece_two_0 = GameObject.Find("lantern_piece_two_0");
            destroy = lantern_piece_two_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternc")
        {

            Debug.Log("lanternc");
            objtag = "lc";
            GameObject lantern_piece_three_0 = GameObject.Find("lantern_piece_three_0");
            destroy = lantern_piece_three_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternd")
        {

            Debug.Log("lanternd");
            objtag = "ld";
            GameObject lantern_piece_four_0 = GameObject.Find("lantern_piece_four_0");
            destroy = lantern_piece_four_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lantern")
        {

            Debug.Log("lantern");
            objtag = "lantern";
            GameObject normal_lantern_0 = GameObject.Find("normal_lantern_0");
            destroy = normal_lantern_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "pagea")
        {

            Debug.Log("pagea");
            objtag = "pa";
            GameObject combine_spell_0 = GameObject.Find("combine_spell_0");
            destroy = combine_spell_0.GetComponent<PickupScript>();

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

                inventory.Add("Keyt");
                keys = keys + 1;

            }

            else if (objtag == "kb")
            {

                inventory.Add("Keyb");
                keys = keys + 1;

            }

            else if (objtag == "la")
            {

                inventory.Add("Lantern Peice a");
                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "lb")
            {

                inventory.Add("Lantern Peice b");
                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "lc")
            {

                inventory.Add("Lantern Peice c");
                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "ld")
            {

                inventory.Add("Lantern Peice d");
                lanternPeices = lanternPeices + 1;

            }

            else if (objtag == "lantern")
            {

                inventory.Add("Normal Lantern");

            }

            else if (objtag == "pa")
            {

                inventory.Add("Lore Page Spell");

            }

            destroy.Destroy();

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