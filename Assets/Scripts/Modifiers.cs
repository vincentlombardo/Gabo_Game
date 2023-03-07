using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifiers
{
    // Start is called before the first frame update
	public List<base_mod> modlist;
	public bool empty = true;

    public string mod_string {get; set;}
	
    Dictionary<string, base_mod> mod_dict = new Dictionary<string, base_mod>(){
        {"base" , new base_mod()},
        {"flying", new isFlying()},
        {"ranged", new isRanged()}
    };
	public Modifiers(string mod_string){
        this.mod_string = mod_string;
		modlist = interpret(mod_string);
	}
	public List<base_mod> interpret(string full_mod_string){
		List<base_mod> templist = new List<base_mod>();
		string[] mod_strings = full_mod_string.Split(' ');
		foreach (string mod_string in mod_strings){
			templist.Add(mod_dict[mod_string]);
		}
		return templist;
	} 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
