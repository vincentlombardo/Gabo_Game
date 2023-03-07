using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state{
    public int slf_hp {get; set;}
    public int opp_hp {get; set;}
    public Attack attk {get; set;}

    public Coordinate slf_pos {get; set;}
    public Coordinate opp_pos {get; set;}

    public Modifiers opp_mods {get; set;}
    public Modifiers self_mods {get; set;}

    public bool att_sucess {get; set;}

    public int incomingdmg; 
	public state(int selfhp,int opphp,Attack currentattack, Coordinate selfpos, Coordinate opppos,Modifiers selfmods,Modifiers oppmods){
        this.slf_hp = selfhp;
        this.attk = currentattack;
        this.opp_hp = opphp;
        this.slf_pos = selfpos;
        this.opp_pos = opppos;
        this.opp_mods = oppmods;
        this.att_sucess = true;
        this.self_mods = selfmods;
        this.incomingdmg = 0;

	}
    public bool apply(){
        if (att_sucess){
            opp_hp -= incomingdmg;
            
        }
        return true;
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
