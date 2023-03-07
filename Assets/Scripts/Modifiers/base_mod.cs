using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class base_mod
{
    // Start is called before the first frame update
     public base_mod(){
       ;
    }
    
    public virtual void run(state curr_state,bool fromself){
                
        Debug.Log("This is a sample base_modifier action");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
