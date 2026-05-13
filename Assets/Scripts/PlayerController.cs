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
    public Stuff stuffScript;

    public string objtag;
   
    public string selectedObj;
    
    
    public PickupScript destroy;
    public Transitions trigger1;
    public Transitions trigger2;
    private Rigidbody2D character;
    private Animator animator;
    private Vector2 moveInput;

    void Start()
    { 
    
        character = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameObject SceneChanger = GameObject.Find("SceneChanger");
        trigger1 = SceneChanger.GetComponent<Transitions>();
        trigger2 = SceneChanger.GetComponent<Transitions>();

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

       objtag = stuffScript.enterTrigger(other.gameObject);

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
                stuffScript.kt();
    


               

            }

            else if (objtag == "kb")
            {
                stuffScript.kb();

               
            }

            else if (objtag == "la")
            {
                stuffScript.la();



            }

            else if (objtag == "lb")
            {
                stuffScript.lb();



            }

            else if (objtag == "lc")
            {
                stuffScript.lc();


            }

            else if (objtag == "ld")
            {
                stuffScript.ld();


            }

            else if (objtag == "lantern")
            {
                stuffScript.lantern();



            }

            else if (objtag == "pa")
            {
                stuffScript.pa();



            }

            destroy.Destroy();

        }

    }

    public void Deselect (InputAction.CallbackContext context)
    {
        stuffScript.ds();


    }

    public void openInventory(InputAction.CallbackContext context)
    {

        if (invOpen == false)
        {

            inventoryCanvas.SetActive(true);
            gameplayCanvas.SetActive(false);
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

    void Update()
    {



    }

}