using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Text_Attk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public Card self_card;
    public TextMeshPro textobj;
    public bool showingattk = false;

    GameManager gm;
    void Start() 
    {
        gm = FindObjectOfType<GameManager>();
        parent = this.transform.parent.gameObject;
        self_card = parent.GetComponent<Card>();
        textobj = this.GetComponent<TextMeshPro>();
        Debug.Log("Attk_Started");
        //text = self_card.gettext(0);
    }
    
    private void OnMouseDown(){
        Debug.Log("Attack was clicked");
        gm.attackisclicked(self_card,0);
    }
    private void OnMouseOver(){
        if(!showingattk){
            Debug.Log("Showing attk");
            gm.showattackrange(self_card,0);
            showingattk = true;
        }

    }
    private void OnMouseExit(){
        showingattk = false;
        gm.clrattackrange();
    }
    

    public bool settext(int num){
        //if(textobj != null) {
        textobj.text = string.Format(self_card.attackinfo[0].namevar + " {0}d", self_card.attackinfo[0].dmg);
        //}
        return true; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
