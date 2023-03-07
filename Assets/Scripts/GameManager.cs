using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Animator camAnim;
	public List<Card> deck;
	public GridManager grid;
	
	public List<Card> discardPile;

	public Card firstcard;
	public Card secondcard;
	public Board board1  {get; set;}
	public CreatePlaceholder currentplaceholder {get; set;}
	public Card currentcard {get; set;}
	private string test_a_range1 = "u2+ d1 l2 r3+ ur2 dl3 dl1";
	private	string test_a_range2 = "u3 dl2";
	private	string test_a_range3 = "dl2";
	private	string test_m_range1 = "u1 d1 l1 r1";
	private	string test_m_range2 = "u2+ d2+ l2+ r2+ dl2";
	private	string test_m_range3 = "dl1 dr1 ul1 ur1";
	private	string test_mods1 = "flying";
	private	string test_mods2 = "flying ranged";
	private string test_mods3 = "base";
	Card opponent;
	Card agressor;
	int attacknum;
	
	void Awake(){
		grid = FindObjectOfType<GridManager>();
	}
	private void Start()
	{
		camAnim = Camera.main.GetComponent<Animator>();
		board1 = new Board(5,5);
		grid.init(5,5,board1);
		//GameObject wizard = GameObject.Find("Wizard_Parent");
		//firstcard = wizard.AddComponent<Card>();
		//firstcard.addboxes();
		//firstcard.Init_2("wizard",new Coordinate(0,0),2,new Modifiers(test_mods1),new boardrange(test_m_range1),new Attack("fireball",new boardrange(test_a_range1),2));
		//GameObject mushroom = GameObject.Find("Mushroom_Parent");
		//secondcard = mushroom.AddComponent<Card>();
		//secondcard.addboxes();
		//secondcard.Init_2("mushroom",new Coordinate(2,2),3,new Modifiers(test_mods2),new boardrange(test_m_range2),new Attack("hit",new boardrange(test_a_range2),1)); 
		
		
		
		//board1.move(firstcard,new Coordinate(1,1));
		//board1.move(secondcard,new Coordinate(1,1));

		

	}
	
	public void simulateattack(){
		Debug.Log("Simulating Attack");
		
		interactioncontext test_1 = new interactioncontext(agressor,opponent,attacknum);
		
		
	}
	public void death(){
		grid.resetmoveillum();
		grid.resetattkcounters();
		currentplaceholder = null;
		currentcard = null;
	}

	public void tileclicked(Coordinate pos){
		interactioncontext test_1 = new interactioncontext(opponent,pos,board1);
		
	}
	private void Update()
	{
		if (currentcard != null){
			grid.resetmoveillum();
			grid.illuminate(currentcard.moverange,currentcard.pos);
		}
	}
	
	public void showattackrange(Card card, int num){
		grid.illuminateattk(card.attackinfo[num].range,card.pos);
	}
	public void clrattackrange(){
		grid.resetattkcounters();
	}
	public void placeholderclicked(Card card){
		
		
		currentplaceholder = card.placeholder;
		currentcard = card;
		grid.resetmoveillum();
        opponent = card;
		card.parent.SetActive(true); 
		


    }
	public void remove(Card card){
		board1.remove(card.pos);
	}
	public void attackisclicked(Card card,int num){
        agressor = card;
		attacknum = num;
		simulateattack();

    }

	void OnGUI()
    {
		
        if (GUI.Button(new Rect(10, 50, 100, 30), "Create Card"))
        {  	
			UnityEngine.Debug.Log("Pressed CreateCard");
			GameObject card_go = new GameObject("Test_Golem");
			
			Createcard cardcreator  = card_go.AddComponent<Createcard>();
			cardcreator.init("Assets/Card_Images/stone_golem.jpeg");
			Card cardobj = card_go.AddComponent<Card>();
			cardobj.Init_2("Stone Golem",new Coordinate(0,0),9,new Modifiers(test_mods2),new boardrange(test_m_range2),new Attack("Smack",new boardrange(test_a_range1),2));
			cardcreator.cardref(cardobj);
			UnityEngine.Debug.Log("Working to CreatePlaceholder");
            
			GameObject placeholder_go = new GameObject("Test_Placeholder");
			CreatePlaceholder placeholder  = placeholder_go.AddComponent<CreatePlaceholder>();
			placeholder.init(cardobj);

			GameObject card_go2 = new GameObject("Test_shroom");
			
			Createcard cardcreator2  = card_go2.AddComponent<Createcard>();
			cardcreator2.init("Assets/Card_Images/evil_shroom.jpeg");
			Card cardobj2 = card_go2.AddComponent<Card>();
			cardobj2.Init_2("shroom",new Coordinate(2,2),2,new Modifiers(test_mods2),new boardrange(test_m_range1),new Attack("fireball",new boardrange(test_a_range2),2));
			cardcreator2.cardref(cardobj2);
			
			GameObject placeholder_go2 = new GameObject("Test_Placeholder");
			CreatePlaceholder placeholder2  = placeholder_go2.AddComponent<CreatePlaceholder>();
			placeholder2.init(cardobj2);
			card_go.transform.position = new Vector3(3f, 0f,0.0f);

			
			UnityEngine.Debug.Log("GuiDone");


        }

		
	
	}
}
