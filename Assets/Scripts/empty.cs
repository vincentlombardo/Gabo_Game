using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty: Card
{
	//public Card( string cardname, int health, string Q, boardrange moverange, Attack a1, Attack s1)
	public empty():base(){
        base.Init(null,null,0,null,null,null,null);
	}
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
