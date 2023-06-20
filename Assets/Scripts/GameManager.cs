using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	public DeckManager deckmanager;
	public GridManager grid;
	public bool startedbool;
	public List<Card> discardPile;
	public List<List<GameObject>> locationlist = new List<List<GameObject>>();

	public Board board1  {get; set;}
	public int attackinghp  {get; set;}
	public List<TextMeshPro> healthpool; 
	public List<Deck> decklist; 
	public CreatePlaceholder currentplaceholder {get; set;}
	public Card currentcard {get; set;}
//	private string test_a_range1 = "u2+ d1 l2 r3+ ur2 dl3 dl1";
//	private	string test_a_range2 = "u1 d1 l1";
//	private	string test_a_range3 = "dl2";
//	private	string test_m_range1 = "u1 d1 l1 r1";
//	private	string test_m_range2 = "u2+ d2+ l2+ r2+ dl2";
//	private	string test_m_range3 = "dl1 dr1 ul1 ur1";
//	private	string test_mods1 = "flying";
//	private	string test_mods2 = "flying ranged";
//	private string test_mods3 = "base";
	private Card opponent;
	private Card agressor;
	private int attacknum;
	private Card selectedinhand;
	private Reader reader;
	private Counter counter;
	private Deck deckselected;
	public int teams;
	private teaminfo colors;
	private Dice movedie;
	private Dice golddie;
	private Counter mcount;
	private TextMeshPro health1;
	private TextMeshPro health2;
	
	public void first(){
		grid = FindObjectOfType<GridManager>();
		reader = FindObjectOfType<Reader>();
		deckmanager = FindObjectOfType<DeckManager>();
		golddie = GameObject.Find("Die_G").GetComponent<Dice>();
		movedie = GameObject.Find("Die_M").GetComponent<Dice>();
		health1 = GameObject.Find("hp1").GetComponent<TextMeshPro>();
		health2 = GameObject.Find("hp2").GetComponent<TextMeshPro>();

		for(int i = 0; i<10;i++){
			List<GameObject> temp = new List<GameObject>();
			GameObject location = GameObject.Find(string.Format("Location ({0})",i));
			if (location != null){
				temp.Add(location);
				temp.Add(null);
				locationlist.Add(temp);
			}

		}
		colors = FindObjectOfType<teaminfo>();
		healthpool.Add(health1);
		healthpool.Add(health2);
	}
	private void second()
	{
		startedbool = false;
		teams = 2;
		board1 = new Board(11,11);
		grid.init(11,11,board1);
		counter = new Counter(teams-1,1);
		int tempindex = 1;
		foreach(var i in locationlist){
			if (tempindex>teams){
				i[0].SetActive(false);
				
			}
			tempindex = tempindex+1;

		}
		
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


	private void Update()
	{
		
		
		if (currentcard != null){
			grid.resetmoveillum();
			grid.illuminate(currentcard.moverange,currentcard.pos);
		}
		int tempindex = 0;
		foreach(var i in locationlist){
			TextMeshPro temptext = i[0].GetComponent<TextMeshPro>();
			GameObject n = i[0].transform.GetChild(0).gameObject;
			SpriteRenderer x = n.GetComponent<SpriteRenderer>();
			if (tempindex == counter.curr){
				
				x.color = new Color32(225, 248, 23,255);
				
			}else{
				x.color = Color.black;
			}
			temptext.color =  colors.colorlist[tempindex];
			tempindex = tempindex+1;

		}

		foreach( TextMeshPro t in healthpool){
			int processed;
			var sucess = int.TryParse(t.text,out processed);
			if(processed<=0){
				Debug.Log("END OF GAME");
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			}
		}
		
	}
	
	public void startgame(){
		Deck deck = deckmanager.createdeck(1,0);
		decklist.Add(deck);
		Card drone = loadcard("drone_duo");
		Card helios = loadcard("helios");
		Card shroom = loadcard("evil_shroom");
		Card froze = loadcard("Frozebro");
		Card ASCII = loadcard("ASCII");
		Card gnomearcher = loadcard("Gnome_Archer");
		Card Ice_Man = loadcard("Ice_Man");
		Card Jack = loadcard("Jack");
		Card Nanos = loadcard("Nano_Swarm");
		Card spare = loadcard("Spare_Parts");
		//Card golem = loadcard("Stone_Golem");
		Card Wiz = loadcard("Wizard");


		//drone.pos = new Coordinate(4,0);
		//drone.team = 3;
			
		deck.addcard(drone);
		deck.addcard(froze);
		deck.addcard(helios);
		deck.addcard(shroom);
		deck.addcard(ASCII);
		deck.addcard(gnomearcher);
		deck.addcard(Ice_Man);
		deck.addcard(Jack);
		deck.addcard(Nanos);
		deck.addcard(spare);
		//deck.addcard(golem);
		deck.addcard(Wiz);
		deck.shuffle();
		grid.setimportsquares(new boardrange("u0r2 u0r3 u0r4 u0r5 u0r6 u0r7 u0r8 u0r9 u0r10"),1);
		grid.setimportsquares(new boardrange("u10r10+ u10r0"),2);

		grid.sethealthsquares(new boardrange("u0r0 u0r1 u1r0 u1r1"),1);
		grid.sethealthsquares(new boardrange("u10r9 u10r10 u9r9 u9r10"),2);

		Deck deck2 = deckmanager.createdeck(2,1);
		decklist.Add(deck2);
		Card drone2 = loadcard("drone_duo");
		Card helios2 = loadcard("helios");
		Card shroom2 = loadcard("evil_shroom");
		Card ASCII2 = loadcard("ASCII");
		Card gnomearcher2 = loadcard("Gnome_Archer");
		Card iceman2 = loadcard("Ice_Man");
		Card Jack2 = loadcard("Jack");
		Card Nanos2 = loadcard("Nano_Swarm");
		Card spare2 = loadcard("Spare_Parts");
		//Card golem2 = loadcard("Stone_Golem");
		Card Wiz2 = loadcard("Wizard");
		

		//drone.pos = new Coordinate(4,0);
		//drone.team = 3;
			
		deck2.addcard(drone2);
		deck2.addcard(helios2);
		deck2.addcard(shroom2);
		deck2.addcard(ASCII2);
		deck2.addcard(gnomearcher2);
		deck2.addcard(iceman2);
		deck2.addcard(Jack2);
		deck2.addcard(Nanos2);
		deck2.addcard(spare2);
		//deck2.addcard(golem2);
		deck2.addcard(Wiz2);
		deck2.shuffle();
		Debug.Log("started");
	}

	


	public void rolled(int value,string name){
		if (name == "Die_M" ){
			mcount = new Counter(value);
			Debug.Log("moverolled");
		}else if(name == "Die_G" ){
			Debug.Log("goldrolled");
			foreach (Deck d in decklist){
				if (d.team == counter.curr+1){
					d.availgold = value;
				}	
				
			}
		}
	}
	public void simulateattack(){
		
		Debug.Log("Simulating Attack");
		
		interactioncontext test_1 = new interactioncontext(agressor,opponent,attacknum);
		if (test_1.attackregister()){
			mcount.next();
		}
		if (mcount.done){
			counter.next();
					
		}
		
		
	}
	public void death(){
		grid.resetmoveillum();
		grid.resetattkcounters();
		currentplaceholder = null;
		currentcard = null;
	}
	public void tileclicked(Coordinate pos,Tile tile){
		if (tile.health != 0){
			attackinghp = tile.health;
		} else if(currentcard != null){
			if (opponent.team == counter.curr+1){
				interactioncontext test_1 = new interactioncontext(opponent,pos,board1);
				if (test_1.moveregister()){
					mcount.next();
				}
				if (mcount.done){
					counter.next();
					
				}
			}
			
		} else if(selectedinhand != null && tile.import == selectedinhand.team){
			foreach (Deck d in decklist){
				if (d.team == counter.curr+1 && selectedinhand.gold <= d.availgold){
					d.availgold -= selectedinhand.gold;
					board1.place(selectedinhand,pos);

					deckselected.played(selectedinhand);
					selectedinhand = null;
					
				}
			}
			
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
		if (card.parent != locationlist[card.team-1][1]){
			card.parent.SetActive(true); 
			card.parent.transform.position = locationlist[card.team-1][0].transform.position;

			if (locationlist[card.team-1][1] != null){
				locationlist[card.team-1][1].SetActive(false);
			}
			locationlist[card.team-1][1] = card.parent;
		}
		


    }
	
	 void OnEnable()
    {
        Debug.Log("OnEnable called");
		
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
		if (scene.name == "Game" && !startedbool ){
			first();
			second();
			startgame();
			Debug.Log("THIS SHOULD HAVE STARTED THE GAME");
			startedbool=true;
		}else {
			Debug.Log(scene.name);
			Debug.Log("THIS IS THE SCENE");
		}
        
    }


	public void remove(Card card){
		board1.remove(card.pos);
	}
	public void attackisclicked(Card card,int num){
		
		
		if (attackinghp != 0){
			
			int processed;
			var sucess = int.TryParse(healthpool[attackinghp-1].text,out processed);
			Debug.Log(processed);
			healthpool[attackinghp-1].text = (processed - card.attackinfo[num].dmg).ToString();
		}
		else if (counter.curr+1 == card.team){
			agressor = card;
			attacknum = num;
			simulateattack();
		}
		attackinghp = 0; 
        

    }

	public void cardinhandselected(Card card, Deck deck){
		if (deck.team == counter.curr+1){
			selectedinhand = card;
			deckselected = deck;
			Debug.Log(string.Format("The card {0} has been selected in your hand",card.namevar));
			
			currentcard = null;
		}
		
	}
	public Card loadcard(string name){
		GameObject go = new GameObject("Test " + name);
		Createcard goCreator  = go.AddComponent<Createcard>();
		Card card = go.AddComponent<Card>();
		string imagepath = reader.interpret(name,card);
		goCreator.init(imagepath);
		goCreator.cardref(card);
		GameObject placeholdergo = new GameObject(name + " Placeholder");
		CreatePlaceholder placeholder  = placeholdergo.AddComponent<CreatePlaceholder>();
		placeholder.init(card);
		
		return card;
	}

//	void OnGUI()
//    {
//		
//        if (GUI.Button(new Rect(10, 50, 100, 30), "Create Card"))
//        {  	
//			UnityEngine.Debug.Log("Pressed CreateCard");
//
//			Card golem = loadcard("stone_golem");
//			golem.pos = new Coordinate(4,4);
//			//golem.transform.position = new Vector3(10f, 4f,0.0f);
//			golem.team = 3;


			//GameObject card_go = new GameObject("Test_Golem");
			//Createcard cardcreator  = card_go.AddComponent<Createcard>();
			//cardcreator.init("Assets/Card_Images/stone_golem.jpeg");
			//Card cardobj = card_go.AddComponent<Card>();
			//cardobj.Init_2("Stone Golem",9,new Modifiers(test_mods2),new boardrange(test_m_range2),new Attack("Smack",new boardrange(test_a_range1),2));
			//string imagepath = reader.interpret("stone_golem",cardobj);
//			Card golem2 = loadcard("stone_golem");
//			golem2.pos = new Coordinate(0,0);
//			golem2.team = 1;
//			//golem.transform.position = new Vector3(3f, 0f,0.0f);
//			//cardcreator.init(imagepath);
//			//cardcreator.cardref(cardobj);
//			//GameObject placeholder_go = new GameObject("Test_Placeholder");
//			//CreatePlaceholder placeholder  = placeholder_go.AddComponent<CreatePlaceholder>();
//			//placeholder.init(cardobj);
//
//			Card shroom = loadcard("evil_shroom");
//			shroom.pos = new Coordinate(2,0);
//			shroom.team = 2;
//		//shroom.transform.position = new Vector3(3f, 4f,0.0f);
//			
//			//cardobj2.Init_2("shroom",2,new Modifiers(test_mods2),new boardrange(test_m_range1),new Attack("fireball",new boardrange(test_a_range2),2));
//			
//			Card drone = loadcard("drone_duo");
//			drone.pos = new Coordinate(4,0);
//			drone.team = 3;
//			//drone.transform.position = new Vector3(6f, 0f,0.0f);

//			Card helios = loadcard("helios");
//			helios.pos = new Coordinate(0,4);
//			helios.team = 4;
//			//helios.transform.position = new Vector3(6f, 4f,0.0f);
//



//        }
//		if (GUI.Button(new Rect(10, 100, 100, 30), "Test"))
//		{  	
//		    startgame();
//		}
//
//		if (GUI.Button(new Rect(10, 0, 100, 30), "Test2"))
//		{  	
//		    Counter counter2 = new Counter(3,3);
//			Debug.Log(string.Format("counter at {0}", counter2.curr));
//			counter2.nextstep();
//			counter2.nextstep();
//			Debug.Log(string.Format("counter at {0}", counter2.curr));
//			counter2.nextstep();
//			Debug.Log(string.Format("counter at {0}", counter2.curr));
////			Debug.Log(string.Format("stepcounter at {0}", counter2.stepcurr));
//
//		}
		
	
//	}
}
