using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactioncontext{
	Card card;
	Card opponent = null;
	Coordinate movepos = null;
    Board card_board;

	int attackindex = -1;
	public interactioncontext(Card card, Coordinate movepos, Board b){
		this.card = card;
		this.movepos = movepos;
        this.card_board = b;
        moveregister();
	}
	public interactioncontext(Card card, Card opponent, int attackindex){
		this.card = card;
		this.opponent = opponent;
		this.attackindex = attackindex;
        attackregister();
	}
    public void attackregister(){
        int cardhp = card.health;
        Modifiers cardmodifiers = card.mods_list;
        Attack attackinquestion = card.attackinfo[attackindex];
        int opphp = opponent.health;
        Modifiers oppmodifiers = opponent.mods_list;
        state newstate = new state(cardhp,opphp,attackinquestion, card.pos, opponent.pos, cardmodifiers,oppmodifiers);
        if (opphp > 0){	
			if(attackinquestion.range.inrange(newstate.slf_pos,newstate.opp_pos)){
				newstate.incomingdmg += attackinquestion.dmg;
				Debug.Log(string.Format(card.namevar + " attacks " + opponent.namevar + " with " + "{0} : {1} dmg",newstate.attk.namevar,newstate.attk.dmg));	
			}else{
				Debug.Log(string.Format(card.namevar + " cannot attack " + opponent.namevar + "\t" + newstate.opp_pos.toString() + " is not in range from" + newstate.slf_pos.toString()));
                newstate.att_sucess = false;
			}
			
		}else {
			Debug.Log("The opponent you are trying to attack is dead");
		}

		
        foreach (base_mod q in cardmodifiers.modlist){
            Debug.Log(string.Format("{0}",q.GetType()));
            q.run(newstate,true);
        }
        foreach (base_mod q in oppmodifiers.modlist){
            Debug.Log(string.Format("{0}",q.GetType()));
            q.run(newstate,false);
        }
        applystate(newstate);
       ///??
    }
    public void applystate(state currentstate){
        currentstate.apply();
        card.health = currentstate.slf_hp;
        opponent.health = currentstate.opp_hp;
        card.pos = currentstate.slf_pos;
        opponent.pos = currentstate.opp_pos;
        card.checkdead();
        opponent.checkdead();
    }

    public bool moveregister(){
        if (card.dead){
            Debug.Log("dead card, cannot move");
        }else{
            if (card.moverange.inrange(card.pos,movepos)){
                if (card_board.board[movepos.xpos][movepos.ypos].GetComponent<empty>() != null){

                    Debug.Log(card.namevar + " moves to " + movepos.toString());
                    var go1 = new GameObject();
                    var empty_1 = go1.AddComponent<empty>();
                    card_board.board[card.pos.xpos][card.pos.ypos] = empty_1;
                    card_board.board[movepos.xpos][movepos.ypos] = card;
                    card.pos = movepos;
                    return true;
                }else{
                    Debug.Log("The Square you want to move to is already occupied");
                }
                

            }else{
                Debug.Log(card.namevar + " cannot move to " + movepos.toString() + " \t not in range");
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
