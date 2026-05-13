using UnityEngine;
using System.Collections.Generic;

public class Stuff : MonoBehaviour
{
    public GameObject keyt;
    public GameObject keyb;
    public GameObject lanterna;
    public GameObject lanternb;
    public GameObject lanternc;
    public GameObject lanternd;
    public GameObject lanternn;
    public GameObject pagea;
    public GameObject keyr;
    public GameObject lanternr;
    public GameObject ikeyt;
    public GameObject ikeyb;
    public GameObject ilanterna;
    public GameObject ilanternb;
    public GameObject ilanternc;
    public GameObject ilanternd;
    public GameObject ilanternn;
    public GameObject ipagea;
    public GameObject ikeyr;
    public GameObject ilanternr;
    public GameObject skeyt;
    public GameObject skeyb;
    public GameObject slanterna;
    public GameObject slanternb;
    public GameObject slanternc;
    public GameObject slanternd;
    public GameObject slanternn;
    public GameObject spagea;
    public GameObject skeyr;
    public GameObject slanternr;
    public GameObject spriteKeyb;
    public GameObject spriteKeyt;
    public GameObject normal_lantern;
    public static Stuff stuffholder;

    [SerializeField] public static int keys = 0;
    [SerializeField] public static int lanternPeices = 0;

    [SerializeField]public static List<string> inventory = new List<string>();

    public PlayerController pc;


    void Awake()
    {
        GameObject play = GameObject.Find("Player");
        pc = play.GetComponent<PlayerController>();
        // If an instance already exists and it's not this one, destroy this one
        if (stuffholder != null && stuffholder != this)
        {
            foreach(string s in inventory)
            {
                if(s == "Repaired Key")
                {
                    Debug.Log("Repaired KEy");
                    ikeyr.SetActive(false);
                    skeyr.SetActive(true);
                    spriteKeyb.SetActive(false);
                    spriteKeyt.SetActive(false);
                    skeyt.SetActive(false);
                    skeyb.SetActive(false);
                    ikeyb.SetActive(false);
                    ikeyt.SetActive(false);

                }

            }
            Destroy(this.gameObject);
            return;
        }

        // Otherwise, set this as the instance
        stuffholder = this;

        // Persist across scenes
        DontDestroyOnLoad(gameObject);

    }


    public string enterTrigger(GameObject thing)
    {
         string objtag = "";
        if (thing.tag == "keyt")
        {

            objtag = "kt";
            GameObject key_piece_top_0 = GameObject.Find("key_piece_top_0");
            pc.destroy = key_piece_top_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "keyb")
        {

            objtag = "kb";
            GameObject key_piece_bottom_0 = GameObject.Find("key_piece_bottom_0");
            pc.destroy = key_piece_bottom_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "lanterna")
        {

            objtag = "la";
            GameObject lantern_piece_one_0 = GameObject.Find("lantern_piece_one_0");
            pc.destroy = lantern_piece_one_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "lanternb")
        {

            objtag = "lb";
            GameObject lantern_piece_two_0 = GameObject.Find("lantern_piece_two_0");
            pc.destroy = lantern_piece_two_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "lanternc")
        {

            objtag = "lc";
            GameObject lantern_piece_three_0 = GameObject.Find("lantern_piece_three_0");
            pc.destroy = lantern_piece_three_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "lanternd")
        {

            objtag = "ld";
            GameObject lantern_piece_four_0 = GameObject.Find("lantern_piece_four_0");
            pc.destroy = lantern_piece_four_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "lantern")
        {

            objtag = "lantern";
            GameObject normal_lantern_0 = GameObject.Find("normal_lantern_0");
            pc.destroy = normal_lantern_0.GetComponent<PickupScript>();

        }

        else if (thing.tag == "pagea")
        {

            objtag = "pa";
            GameObject combine_spell_0 = GameObject.Find("combine_spell_0");
            pc.destroy = combine_spell_0.GetComponent<PickupScript>();

        }
        return objtag;
    }

    public void kt()
    {
         Debug.Log(keys);
        keys = keys + 1;

        if(keys == 2)
        {
            keyt.SetActive(false);                    
            keyb.SetActive(false);
            ikeyt.SetActive(false);
            ikeyb.SetActive(false);
            skeyt.SetActive(false);
            skeyb.SetActive(false);
            keyr.SetActive(true);
            ikeyr.SetActive(true);
            skeyr.SetActive(true);
            inventory.Add("Repaired Key");
            pc.selectedObj = "Repiared Key";
            pc.trigger1.trigger1();

        }

        else
        {

            inventory.Add("Keyt");
            pc.selectedObj = ("Keyt");
            keyt.SetActive(true);
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

    public void kb()
    {
         Debug.Log(keys);
                keys = keys + 1;

                if(keys == 2)
                {

                    keyt.SetActive(false);
                    keyb.SetActive(false);
                    ikeyt.SetActive(false);
                    ikeyb.SetActive(false);
                    skeyt.SetActive(false);
                    skeyb.SetActive(false);
                    keyr.SetActive(true);
                    ikeyr.SetActive(true);
                    skeyr.SetActive(true);
                    inventory.Add("Repaired Key");
                    pc.selectedObj = ("Repaired Key");
                    pc.trigger1.trigger1();

                }

                else
                {

                    inventory.Add("Keyb");
                    keys = keys + 1;
                    pc.selectedObj = ("Keyb");
                    keyt.SetActive(false);
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

    public void la()
    {
                inventory.Add("Lantern Peice a");
                lanternPeices = lanternPeices + 1;
                pc.selectedObj = ("Lantern Peice a");
                keyt.SetActive(false);
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
                    pc.selectedObj = ("Repaired Lantern");
                    pc.trigger2.trigger2();

                }
    }
    public void lb()
    {
                inventory.Add("Lantern Peice b");
                lanternPeices = lanternPeices + 1;
                pc.selectedObj = ("Lantern Peice b");
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
    public void lc()
    {
        
                inventory.Add("Lantern Peice c");
                lanternPeices = lanternPeices + 1;
                pc.selectedObj = ("Lantern Peice c");
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

    public void ld()
    {
        
                inventory.Add("Lantern Peice d");
                lanternPeices = lanternPeices + 1;
                pc.selectedObj = ("Lantern Peice d");
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
    public void lantern()
    {
                        inventory.Add("Normal Lantern");
                pc.selectedObj = ("Normal Lantern");
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

    public void pa()
    {
                        inventory.Add("Lore Page Spell");
                pc.selectedObj = ("Lore Page Spell");
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

    public void ds()
    {
        
        pc.selectedObj = ("");
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

}

