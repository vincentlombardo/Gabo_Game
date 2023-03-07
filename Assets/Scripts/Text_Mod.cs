using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Text_Mod : MonoBehaviour
{
    public GameObject parent;
    public Card self_card;
    public TextMeshPro textobj;

    GameManager gm;
    void Start() 
    {
        gm = FindObjectOfType<GameManager>();
        parent = this.transform.parent.gameObject;
        self_card = parent.GetComponent<Card>();
        textobj = this.GetComponent<TextMeshPro>();
        Debug.Log("Mod_Started");
        //text = self_card.gettext(0);
    }
    
   
    public bool settext(){
        Start();
        //if(textobj != null) {
        textobj.text = string.Format("- " + self_card.mods_list.mod_string);
        //}
        return true; 
    }
}
