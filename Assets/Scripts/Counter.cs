using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter
{
    // Start is called before the first frame update
    public int max {get;set;}
    public int stepmax {get;set;}
    public int stepcurr {get;set;}
    public int curr {get;set;}
    public bool done = false;
    
    public Counter(int max, int stepmax = 1){
        this.max = max;
        this.stepmax = stepmax;
        curr = 0;
        stepcurr = 0;
        
    }
    public void next(){
        
        if (curr == max){
            curr = 0;
        }else{
            curr +=1;
            if (curr==max){
                done = true;
            }
        }
    }
    public void nextstep(){
        if (stepcurr == stepmax){
            stepcurr = 0;
            
        }else{
            stepcurr +=1;
            if (stepcurr == stepmax){
                next();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
