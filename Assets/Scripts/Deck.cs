using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Deck:MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> drawpile{get;set;}
    public List<Card> discardpile{get;set;}
    GameManager gm;
    public string player = "Player";

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        

    }

    public void addcard(Card card){
        drawpile.Add(card);
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
        var retstr = player + "Deck : ";
        foreach (Card card in drawpile){
            retstr += card.name + "\t";
        }
        return retstr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
