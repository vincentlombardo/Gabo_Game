using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class boardrange
{
    public List<(int,int)> rangelist {get;set;}
    Dictionary<string, (int,int)> dirdict = new Dictionary<string, (int,int)>(){
	{"u", (0,1)},
	{"d",(0,-1)},
	{"l",(-1,0)},
    {"r",(1,0)}
    };
	public boardrange(string rangestr){
		rangelist = interpret(rangestr);

	}
    public List<(int,int)> interpret(string rangestr){
        int num = 0;
        string[] bounds = rangestr.Split(' ');
        List<(int,int)> temprangelist = new List<(int,int)>();
        foreach (string b in bounds){
            var i = b;
            int x = 0;
            int y = 0;
            bool between = false;
            if (i.Contains("+")){
                between = true;
                i = i.Remove(i.IndexOf("+"),1);
            }
            foreach (var key in dirdict.Keys){
                if (i.Contains(key)){
                    x += dirdict[key].Item1;
                    y += dirdict[key].Item2;
                    i = i.Remove(i.IndexOf(key),1);
                }
            }
            

            var sucess = int.TryParse(i,out num);
            if (between){
                for(int n = 1; n <= num; n++){
                    temprangelist.Add((n*x,n*y));
                    //Console.WriteLine(string.Format("{0},{1}",n*x,n*y));
                }
            }else{
                temprangelist.Add((x*num,y*num));
                //Console.WriteLine(string.Format("{0},{1}",x*num,y*num));
            }
        }
		return temprangelist;
    }
	public bool inrange(Coordinate self_pos, Coordinate opp_pos){
		foreach (var posssquare in rangelist){
			int poss_x = posssquare.Item1 + self_pos.xpos;
			int poss_y =  posssquare.Item2 +self_pos.ypos;
			if (opp_pos.xpos == poss_x && opp_pos.ypos == poss_y){
				
				return true;
			}
		}
		return false;
		
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
