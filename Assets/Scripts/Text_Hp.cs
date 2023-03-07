using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 


public class Text_Hp : MonoBehaviour
{
    public GameObject parent;
    public Card self_card;
    public TextMeshPro textobj;
    public bool placeholder = false;

    public void placeholderinit(Card card){
        self_card = card;
        placeholder = true;
    }
    void Start()
    {
        parent = this.transform.parent.gameObject;
        //Debug.Log(parent.name + "<<<< NAME");
        if (!placeholder){
            
            
            self_card = parent.GetComponent<Card>();
        }
        
        
        textobj = this.GetComponent<TextMeshPro>();
        //Debug.Log(textobj.text + "<<<< Text");
        Debug.Log("HP_Started");
    }

    public bool sethp(int num){
        if (textobj != null){
            textobj.text = num.ToString() + " HP";
            return true;
        }
        return false;
        
    }
    public bool settext(){
       //

        textobj.text = string.Format("{0} HP",self_card.health);
       //}
        return true;
        
       
        
    }
    void Update()
    {
        
    }
}
