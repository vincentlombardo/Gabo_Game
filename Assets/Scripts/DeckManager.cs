using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    GameManager gm;
    [SerializeField] public GameObject _pointprefab;
    [SerializeField] public GameObject _deckprefab;
    public List<Deck> decklist{get;set;}
    public float startingposy = 9.11f;
    public float startingposx = -40.49f;


    // Start is called before the first frame update
    void Awake()
    {
        decklist = new List<Deck>();
    }


    public Deck createdeck(int team,int num){
        startingposy = startingposy - startingposy *num *.75f;
        var pointlist1 = new List<pointbehavior>();
        var deckobj = Instantiate(_deckprefab,new Vector3(startingposx,startingposy,1),Quaternion.identity);
        Deck deck = deckobj.AddComponent<Deck>();
        deck.init(team);
        for(int i = 0; i<5;i++){
            var point = Instantiate(_pointprefab,new Vector3(startingposx+6 + i*3,startingposy),Quaternion.identity);
            var pointscrpt = point.GetComponent<pointbehavior>();
            pointscrpt.deck = deck;
            pointscrpt.posindeck = i;
            pointlist1.Add(pointscrpt);
        }
        
        decklist.Add(deck);
        deck.pointlist = pointlist1;
        Debug.Log(deck.pointlist[1].name);
        Debug.Log("The name of the gameobject");
        return deck;
        
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
