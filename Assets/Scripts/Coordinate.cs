using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate
{
    // Start is called before the first frame update
	public int xpos { get; set;}
	public int ypos { get; set;} 

	public Coordinate(int xpos, int ypos){
		this.xpos = xpos;
		this.ypos = ypos;
	}
	public string toString(){
		return string.Format("({0},{1})",xpos,ypos);
	}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
