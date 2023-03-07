using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board{
	public List<List<Card>> board = new List<List<Card>>();
	public Board(int height, int width){
		for (int i = 0; i < height; i++) {
			List<Card> row = new List<Card>();
			for (int j = 0; j < width; j++) {
                var go1 = new GameObject();
				row.Add(go1.AddComponent<empty>());
				
			}
			board.Add(row);
		}
		Debug.Log(board);
		Debug.Log("-");
		
		
	}
	public bool place(Card card, Coordinate pos){
		Debug.Log(string.Format(card.namevar + " replaces {0} at " + pos.toString() ,board[pos.xpos][pos.ypos].GetType()));
		board[pos.xpos][pos.ypos] = card;
		card.pos = pos;
		return true;

	}
	
	public Card get(Coordinate pos){
		return board[pos.xpos][pos.ypos];
	}
	public void remove(Coordinate pos){
		var go1 = new GameObject();
		
		board[pos.xpos][pos.ypos] = go1.AddComponent<empty>();
		
				
	}
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
