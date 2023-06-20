using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
public class Reader : MonoBehaviour
{
    public string namestr{get;set;}
    public string gamename{get;set;}
    public int hp{get;set;}
    public string movestr{get;set;}
    public string attkstr {get;set;}
    public string qstr{get;set;}
    public int gold {get;set;}
    
    public string interpret(string namestr, Card card){
        this.namestr = namestr;
        
    
        // Create an instance of StreamReader to read from a file.
        // The using statement also closes the StreamReader.
        string path = "Assets/Card_Data/" + namestr + "/Info.txt";
        string imagepath = "Assets/Card_Data/" + namestr + "/Image.jpeg";
    
        Debug.Log(path);
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                string[] id_info = line.Split(':');
                if(id_info[0] == "n"){
                    gamename = id_info[1];
                }else if(id_info[0] == "hp"){
                    hp = Int32.Parse(id_info[1]);
                }else if(id_info[0] == "q"){
                    qstr = id_info[1];
                }else if(id_info[0] == "m"){
                    movestr = id_info[1];
                }else if(id_info[0] == "a"){
                    attkstr = id_info[1];
                }else if(id_info[0] == "g"){
                    gold = Int32.Parse(id_info[1]);
                }else{
                    Debug.Log("Uh oh");
                }
                Debug.Log(line);
            }
        }
        string[] alist = attkstr.Split(",");
        int admg = Int32.Parse(alist[2]);
        card.Init_2(gamename,hp,new Modifiers(qstr),new boardrange(movestr),new Attack(alist[0],new boardrange(alist[1]),admg),gold);
        Debug.Log(imagepath);
        return imagepath;
        
       
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
