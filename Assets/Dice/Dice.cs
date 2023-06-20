using System.Collections;
using UnityEngine;
using System.Collections.Generic;

using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Dice : MonoBehaviour {

    public int value {get;set;}
    // Array of dice sides sprites to load from Resources folder
    public List<Sprite> diceSides = new List<Sprite>();
    GameManager gm;
    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

	// Use this for initialization
	private void Start () {
        gm = FindObjectOfType<GameManager>();

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();
        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        
	}
	
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        int finalSide = 0;
        int sign;
        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 10; i++)
        {   
            
            if(i <= 5){
                 sign = -1;
            }else{
                sign = 1;
            }
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);
            

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];


            // Pause before next itteration
            this.transform.position = new Vector3(this.transform.position.x + .25f * sign,this.transform.position.y,this.transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
        
        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
        value = finalSide;
        gm.rolled(value,this.name);
        // Show final dice value in Console
        Debug.Log(finalSide);
    }
}
