using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class isFlying: base_mod{
    public isFlying(){
        ;
    }
    public override void run(state curr_state, bool fromself){

        Debug.Log("This is a sample modifier action for flying");
        if (!fromself){
            if (curr_state.self_mods.modlist.OfType<isRanged>().Any()){
                        Debug.Log("Opponent is ranged this will hit");
            }else{
                curr_state.att_sucess = false;
                Debug.Log("Is not ranged, flying evades");
            }
        }
        

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
