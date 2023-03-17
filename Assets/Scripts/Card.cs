using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Animations;
public class Card : MonoBehaviour
{
	public GameObject parent {get; set;}
	public bool dead {get; set;}
	public string imagename  {get; set;}
	public Coordinate pos {get; set;}
	public Text_Attk attktext;
	public Text_Hp hptext;
	GameManager gm;
	public string firsttext = "ahhh";
	private Animator camAnim;
	public int team { get; set;}
	public string namevar { get; set;}
	public int health { get; set;}

	public List<Attack> attackinfo { get; set;}

	public boardrange moverange {get; set;}
	public Modifiers mods_list { get; set;}
	public CreatePlaceholder placeholder {get;set;}

	
	public void Init( string cardname, int health, Modifiers Q,boardrange moverange, Attack a1, Attack s1){

		attackinfo = new List<Attack>();
		this.namevar = cardname;
		this.health = health;
		this.attackinfo.Add(a1);
		this.attackinfo.Add(s1);
		this.mods_list = Q; 
		this.moverange = moverange;
		dead = false;
		
        
	}
	
	public void Init_2(string cardname, int health, Modifiers Q,boardrange moverange, Attack a1){
        
		attackinfo = new List<Attack>();
		this.namevar = cardname;
		this.health = health;
		this.attackinfo.Add(a1);
		this.mods_list = Q; 
		this.moverange = moverange;
		dead = false;
		
        
	}
	
	
	
	
	public bool checkdead(){
		if (health <= 0 || dead){
			dead = true;
			health = 0;
			gameObject.SetActive(false); 
			gm.remove(this);
			gm.death();
		}
		return dead;
	}
	
	public string toString(){
		string healthstr = string.Format("Heath : {0}",health);
		string statusstr;
		if (dead){
			statusstr = "Status : Dead";
		} else {
			statusstr = "Status : Alive";
		}
		string final = " ------- \n" + namevar + "\n" + healthstr + "\n" + statusstr + "\n ------- \n";

		return final;
	}
	
	void Awake()
	{
		
		gm = FindObjectOfType<GameManager>();
		parent = gameObject;
		
	}
	void Start()
	{	
		gm.board1.place(this,pos);
		parent.SetActive(false);
	}
	public void addboxes(){
		var attktext_go = this.transform.Find("Attk_Text").gameObject;
		attktext = attktext_go.AddComponent<Text_Attk>();
		var hptext_go = this.transform.Find("HP_Text").gameObject;
		hptext = hptext_go.AddComponent<Text_Hp>();
	}
	

	void Update()
	{
		hptext = this.transform.Find("HP_Text").gameObject.GetComponent<Text_Hp>();
		attktext = this.transform.Find("Attk_Text").gameObject.GetComponent<Text_Attk>();
		hptext.sethp(health);
		

		
		
	}
	
	
	

	
	

}
