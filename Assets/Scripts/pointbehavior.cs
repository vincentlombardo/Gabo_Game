using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class pointbehavior : MonoBehaviour
{
    public GameManager gm;
    public GameObject parent;
    public int posindeck{get;set;}
    public Deck deck {get;set;}
    public int gold {get;set;}
    public TextMeshPro goldtext;

    // Start is called before the first frame update
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
		parent = gameObject;
        goldtext = this.GetComponent<TextMeshPro>();
    }

    private void OnMouseDown(){
        deck.cardselected(posindeck);
    }
    // Update is called once per frame
    void Update()
    {
        if (gold != 0 ){
            goldtext.text = string.Format("G : {0}",gold);
        }else{
            goldtext.text = string.Format("");
        }
    }
}
