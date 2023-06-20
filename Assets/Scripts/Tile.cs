using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor;
    public Color hpColor;
    public Color offsetColor;
    public Color highlightcolor;
    public Color importcolor;
    public SpriteRenderer renderer;
    public GameManager gm;
    public GameObject parent;
    public Color savecolor;
    public teaminfo colors;
    public int import{get;set;}
    public int health{get;set;}
    public float transx{get;set;}
    public float transy{get;set;}//transform


    public int boardposx {get;set;}
    public int boardposy {get;set;}

    public void init(bool isOffset, float xpos, float ypos,int boardposx,int boardposy){
        this.boardposx = boardposx;
        this.boardposy = boardposy;
        transx = xpos;
        transy = ypos;
        renderer = gameObject.GetComponent<SpriteRenderer>();
        
        if (isOffset){
            renderer.color = offsetColor;
        }else{
            renderer.color = baseColor;
        }
        savecolor = renderer.color;
        this.import = 0;
        this.health = 0;
    }
    public void illuminate(){
        renderer.color = highlightcolor;
    }
    public void setimportsquare(int team){
        renderer.color = colors.colorlist[team-1];
        savecolor = colors.colorlist[team-1];
        this.import = team;
    }
    public void sethealthsquare(int team){
        renderer.color = hpColor;
        savecolor = hpColor;
        this.health = team;
    }
    // Start is called before the first frame update
    public void reset(){
        renderer.color = savecolor;
    }
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
		parent = gameObject;
        colors = FindObjectOfType<teaminfo>();
    }
    private void OnMouseDown(){
        gm.tileclicked(new Coordinate(boardposx,boardposy),this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
