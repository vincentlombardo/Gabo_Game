using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public string namevar { get; set;}
	public boardrange range { get; set;}
	public int dmg { get; set;}
    public bool targetsameteam { get; set;}

    public Attack(string namevar, boardrange range, int dmg){
		this.namevar = namevar;
		this.range = range;
		this.dmg = dmg;
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
