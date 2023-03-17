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
		rangelist = interpret2(rangestr);

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
    public List<(int,int)> interpret2(string rangestr){
        // ex u1d2 u1+l2 
        string[] bounds = rangestr.Split(' ');
        string key;
        List<(int,int)> finalrange = new List<(int,int)>();
        
        foreach (string bound in bounds){
            Debug.Log(bound);
            char[] individualchars = bound.ToCharArray();
            var index = -1;
            List<List<(int,int)>> temprangelist = new List<List<(int,int)>>();
            foreach(char _char in individualchars){
                index +=1;
                var between = false;
                var num = 0;
                string[] keyslist = dirdict.Keys.ToArray();
                
                int posindict = System.Array.IndexOf(keyslist, _char.ToString());
                
                
                if (posindict != -1 ){
                    key = _char.ToString();
                    var temp = new List<(int,int)>();
                    
                    var sucess = int.TryParse(individualchars[index+1].ToString(),out num);
                    if (sucess){
                        if (individualchars.Length > index+2 && individualchars[index+2].ToString() == "+"){
                            between = true;
                        }
                        Debug.Log("There is a sucessful char");
                        if (between){
                            for(int n = 1; n <= num; n++){
                                temp.Add((n*dirdict[key].Item1,n*dirdict[key].Item2));
                                //Console.WriteLine(string.Format("{0},{1}",n*dirdict[key].Item1,n*dirdict[key].Item2));
                            }
                        }else{
                            temp.Add((dirdict[key].Item1*num,dirdict[key].Item2*num));
                            //Console.WriteLine(string.Format("{0},{1}",dirdict[key].Item1*num,dirdict[key].Item2*num));
                        }
                    }
                    temprangelist.Add(temp);
                }
            }
            
            foreach (var coord1 in temprangelist[0]){
                if (temprangelist.Count > 1){
                    foreach (var coord2 in temprangelist[1]){
                        finalrange.Add((coord1.Item1 + coord2.Item1,coord1.Item2 + coord2.Item2));
                        Debug.Log(string.Format("Between coord : {0},{1}",coord1.Item1 + coord2.Item1,coord1.Item2 + coord2.Item2));
                    }
                }else{
                    finalrange.Add((coord1.Item1,coord1.Item2));
                    Debug.Log(string.Format("Single Coord: {0},{1}",coord1.Item1,coord1.Item2));

                }
            }
            
                
            

        }
       
        return finalrange;


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
