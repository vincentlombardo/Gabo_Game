using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Deck : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> drawpile{get;set;}
    public List<Card> discardpile{get;set;}
    public List<pointbehavior> pointlist {get;set;}
    public int availgold {get;set;}
    public List<Card> currhand{get;set;}
    GameManager gm;
    public int team {get;set;}
    GameObject parent;  
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        parent = gameObject;
        
    }
    public void init(int team){
        currhand = new List<Card>();
        drawpile = new List<Card>();
        discardpile = new List<Card>();
        this.team = team;
    }
    public void addcard(Card card){
        drawpile.Add(card);
        card.team = this.team;
    }
    public void played(Card card){
        Debug.Log(string.Format("played is called {0}",currhand.Count));
        for(int i = 0; i < currhand.Count; i++){
            if (currhand[i] == card){
                Debug.Log("We found the culprit");
                card.parent.transform.position = new Vector3(-20f,0f,0f);
                card.parent.SetActive(false);
                currhand.RemoveAt(i);
            }
        }
    }
    private List<Card> ShuffleList(List<Card> list)
    {
        var random = new System.Random();
        var newShuffledList = new List<Card>();
        var listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            var randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }   
    public void shuffle(){
        drawpile = ShuffleList(drawpile);
    }
    public string toString(){
        var retstr = String.Format("Player {0} Deck: ",team);
        foreach (Card card in drawpile){
            retstr += card.name + "\t";
        }
        return retstr;
    }
    public void draw(){
        Debug.Log("points");
        Debug.Log(pointlist.Count);
        currhand.Add(drawpile[0]);
        drawpile.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {   
        foreach (var i in pointlist){
            i.gold = 0;
        }

        if (pointlist.Count == 5){
            for(int i=0; i<currhand.Count; i++){
                currhand[i].parent.transform.position = pointlist[i].parent.transform.position;
                pointlist[i].gold = currhand[i].gold;
                currhand[i].parent.SetActive(true);
                currhand[i].activecollider = false;
            }
            
        }
    }

    public void cardselected(int index){
        if (currhand[index] != null){
            Debug.Log(string.Format("{0} - index of card selected",index));
            gm.cardinhandselected(currhand[index],this);

        }
    }
    private void OnMouseDown(){
        if (drawpile.Count != 0 && currhand.Count < 5 ){
            draw();
        }
    }
}
