using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHealer : base_mod
{
    public IsHealer(){
        ;
    }
    public override void run(state curr_state, bool fromself){
       Debug.Log("This is a sample modifier action for Healer");
       if(fromself){
        curr_state.incomingdmg = curr_state.incomingdmg*-1;
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
