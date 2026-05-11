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
    public int keys = 0;
    public int lanternPeices = 0;
    public string selectedObj;
    public List<string> inventory = new List<string>();
    
    private PickupScript destroy;
    private Transitions trigger1;
    private Transitions trigger2;
    private Rigidbody2D character;
    private Animator animator;
    private Vector2 moveInput;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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
        if (other.gameObject.tag == "keyt")
        {

            objtag = "kt";
            GameObject key_piece_top_0 = GameObject.Find("key_piece_top_0");
            destroy = key_piece_top_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "keyb")
        {

            objtag = "kb";
            GameObject key_piece_bottom_0 = GameObject.Find("key_piece_bottom_0");
            destroy = key_piece_bottom_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanterna")
        {

            objtag = "la";
            GameObject lantern_piece_one_0 = GameObject.Find("lantern_piece_one_0");
            destroy = lantern_piece_one_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternb")
        {

            objtag = "lb";
            GameObject lantern_piece_two_0 = GameObject.Find("lantern_piece_two_0");
            destroy = lantern_piece_two_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternc")
        {

            objtag = "lc";
            GameObject lantern_piece_three_0 = GameObject.Find("lantern_piece_three_0");
            destroy = lantern_piece_three_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lanternd")
        {

            objtag = "ld";
            GameObject lantern_piece_four_0 = GameObject.Find("lantern_piece_four_0");
            destroy = lantern_piece_four_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "lantern")
        {

            objtag = "lantern";
            GameObject normal_lantern_0 = GameObject.Find("normal_lantern_0");
            destroy = normal_lantern_0.GetComponent<PickupScript>();

        }

        else if (other.gameObject.tag == "pagea")
        {

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

                Debug.Log(keys);
                keys = keys + 1;

                if(keys == 2)
                {

                    stuffScript.keyt.SetActive(false);
                    keyb.SetActive(false);
                    ikeyt.SetActive(false);
                    ikeyb.SetActive(false);
                    skeyt.SetActive(false);
                    skeyb.SetActive(false);
                    keyr.SetActive(true);
                    ikeyr.SetActive(true);
                    skeyr.SetActive(true);
                    inventory.Add("Repaired Key");
                    selectedObj = ("Repaired Key");
                    trigger1.trigger1();

                }

                else
                {

                    inventory.Add("Keyt");
                    selectedObj = ("Keyt");
                    stuffScript.keyt.SetActive(true);
                    keyb.SetActive(false);
                    lanterna.SetActive(false);
                    lanternb.SetActive(false);
                    lanternc.SetActive(false);
                    lanternd.SetActive(false);
                    lanternn.SetActive(false);
                    pagea.SetActive(false);
                    lanternr.SetActive(false);
                    ikeyt.SetActive(true);
                    ikeyb.SetActive(false);
                    ilanterna.SetActive(false);
                    ilanternb.SetActive(false);
                    ilanternc.SetActive(false);
                    ilanternd.SetActive(false);
                    ilanternn.SetActive(false);
                    ipagea.SetActive(false);
                    ilanternr.SetActive(false);
                    skeyt.SetActive(true);

                }

            }

            else if (objtag == "kb")
            {

                Debug.Log(keys);
                keys = keys + 1;

                if(keys == 2)
                {

                    stuffScript.keyt.SetActive(false);
                    keyb.SetActive(false);
                    ikeyt.SetActive(false);
                    ikeyb.SetActive(false);
                    skeyt.SetActive(false);
                    skeyb.SetActive(false);
                    keyr.SetActive(true);
                    ikeyr.SetActive(true);
                    skeyr.SetActive(true);
                    inventory.Add("Repaired Key");
                    selectedObj = ("Repaired Key");
                    trigger1.trigger1();

                }

                else
                {

                    inventory.Add("Keyb");
                    keys = keys + 1;
                    selectedObj = ("Keyb");
                    stuffScript.keyt.SetActive(false);
                    keyb.SetActive(true);
                    lanterna.SetActive(false);
                    lanternb.SetActive(false);
                    lanternc.SetActive(false);
                    lanternd.SetActive(false);
                    lanternn.SetActive(false);
                    pagea.SetActive(false);
                    lanternr.SetActive(false);
                    ikeyt.SetActive(false);
                    ikeyb.SetActive(true);
                    ilanterna.SetActive(false);
                    ilanternb.SetActive(false);
                    ilanternc.SetActive(false);
                    ilanternd.SetActive(false);
                    ilanternn.SetActive(false);
                    ipagea.SetActive(false);
                    ilanternr.SetActive(false);
                    skeyb.SetActive(true);

                }

            }

            else if (objtag == "la")
            {

                inventory.Add("Lantern Peice a");
                lanternPeices = lanternPeices + 1;
                selectedObj = ("Lantern Peice a");
                stuffScript.keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(true);
                lanternb.SetActive(false);
                lanternc.SetActive(false);
                lanternd.SetActive(false);
                lanternn.SetActive(false);
                pagea.SetActive(false);
                keyr.SetActive(false);
                ikeyt.SetActive(false);
                ikeyb.SetActive(false);
                ilanterna.SetActive(true);
                ilanternb.SetActive(false);
                ilanternc.SetActive(false);
                ilanternd.SetActive(false);
                ilanternn.SetActive(false);
                ipagea.SetActive(false);
                ikeyr.SetActive(false);
                slanterna.SetActive(true);

                if(lanternPeices == 4)
                {

                    lanterna.SetActive(false);
                    lanternb.SetActive(false);
                    lanternc.SetActive(false);
                    lanternd.SetActive(false);
                    ilanterna.SetActive(false);
                    ilanternb.SetActive(false);
                    ilanternc.SetActive(false);
                    ilanternd.SetActive(false);
                    slanterna.SetActive(false);
                    slanternb.SetActive(false);
                    slanternc.SetActive(false);
                    slanternd.SetActive(false);
                    lanternr.SetActive(true);
                    ilanternr.SetActive(true);
                    slanternr.SetActive(true);
                    inventory.Add("Repaired Lantern");
                    selectedObj = ("Repaired Lantern");
                    trigger2.trigger2();

                }

            }

            else if (objtag == "lb")
            {

                inventory.Add("Lantern Peice b");
                lanternPeices = lanternPeices + 1;
                selectedObj = ("Lantern Peice b");
                keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(false);
                lanternb.SetActive(true);
                lanternc.SetActive(false);
                lanternd.SetActive(false);
                lanternn.SetActive(false);
                pagea.SetActive(false);
                keyr.SetActive(false);
                ikeyt.SetActive(false);
                ikeyb.SetActive(false);
                ilanterna.SetActive(false);
                ilanternb.SetActive(true);
                ilanternc.SetActive(false);
                ilanternd.SetActive(false);
                ilanternn.SetActive(false);
                ipagea.SetActive(false);
                ikeyr.SetActive(false);
                slanternb.SetActive(true);

            }

            else if (objtag == "lc")
            {

                inventory.Add("Lantern Peice c");
                lanternPeices = lanternPeices + 1;
                selectedObj = ("Lantern Peice c");
                keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(false);
                lanternb.SetActive(false);
                lanternc.SetActive(true);
                lanternd.SetActive(false);
                lanternn.SetActive(false);
                pagea.SetActive(false);
                keyr.SetActive(false);
                ikeyt.SetActive(false);
                ikeyb.SetActive(false);
                ilanterna.SetActive(false);
                ilanternb.SetActive(false);
                ilanternc.SetActive(true);
                ilanternd.SetActive(false);
                ilanternn.SetActive(false);
                ipagea.SetActive(false);
                ikeyr.SetActive(false);
                slanternc.SetActive(true);

            }

            else if (objtag == "ld")
            {

                inventory.Add("Lantern Peice d");
                lanternPeices = lanternPeices + 1;
                selectedObj = ("Lantern Peice d");
                keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(false);
                lanternb.SetActive(false);
                lanternc.SetActive(false);
                lanternd.SetActive(true);
                lanternn.SetActive(false);
                pagea.SetActive(false);
                keyr.SetActive(false);
                ikeyt.SetActive(false);
                ikeyb.SetActive(false);
                ilanterna.SetActive(false);
                ilanternb.SetActive(false);
                ilanternc.SetActive(false);
                ilanternd.SetActive(true);
                ilanternn.SetActive(false);
                ipagea.SetActive(false);
                keyr.SetActive(false);
                slanternd.SetActive(true);

            }

            else if (objtag == "lantern")
            {

                inventory.Add("Normal Lantern");
                selectedObj = ("Normal Lantern");
                keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(false);
                lanternb.SetActive(false);
                lanternc.SetActive(false);
                lanternd.SetActive(false);
                lanternn.SetActive(true);
                pagea.SetActive(false);
                keyr.SetActive(false);
                lanternr.SetActive(false);
                ilanterna.SetActive(false);
                ilanternb.SetActive(false);
                ilanternc.SetActive(false);
                ilanternd.SetActive(false);
                ilanternn.SetActive(true);
                ipagea.SetActive(false);
                ikeyr.SetActive(false);
                ilanternr.SetActive(false);
                slanternn.SetActive(true);

            }

            else if (objtag == "pa")
            {

                inventory.Add("Lore Page Spell");
                selectedObj = ("Lore Page Spell");
                keyt.SetActive(false);
                keyb.SetActive(false);
                lanterna.SetActive(false);
                lanternb.SetActive(false);
                lanternc.SetActive(false);
                lanternd.SetActive(false);
                lanternn.SetActive(false);
                pagea.SetActive(true);
                keyr.SetActive(false);
                lanternr.SetActive(false);
                ikeyt.SetActive(false);
                ikeyb.SetActive(false);
                ilanterna.SetActive(false);
                ilanternb.SetActive(false);
                ilanternc.SetActive(false);
                ilanternd.SetActive(false);
                ilanternn.SetActive(false);
                ipagea.SetActive(true);
                ikeyr.SetActive(false);
                ilanternr.SetActive(false);
                spagea.SetActive(true);

            }

            destroy.Destroy();

        }

    }

    public void Deselect (InputAction.CallbackContext context)
    {

        selectedObj = ("");
        keyt.SetActive(false);
        keyb.SetActive(false);
        lanterna.SetActive(false);
        lanternb.SetActive(false);
        lanternc.SetActive(false);
        lanternd.SetActive(false);
        lanternn.SetActive(false);
        pagea.SetActive(false);
        keyr.SetActive(false);
        lanternr.SetActive(false);
        ikeyt.SetActive(false);
        ikeyb.SetActive(false);
        ilanterna.SetActive(false);
        ilanternb.SetActive(false);
        ilanternc.SetActive(false);
        ilanternd.SetActive(false);
        ilanternn.SetActive(false);
        ipagea.SetActive(false);
        ikeyr.SetActive(false);
        ilanternr.SetActive(false);

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