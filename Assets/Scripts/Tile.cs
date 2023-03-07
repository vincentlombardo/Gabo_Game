using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color baseColor;
    public Color offsetColor;
    public Color highlightcolor;
    public SpriteRenderer renderer;
    public GameManager gm;
    public GameObject parent;
    public Color savecolor;
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
    }
    public void illuminate(){
        renderer.color = highlightcolor;
    }
    // Start is called before the first frame update
    public void reset(){
        renderer.color = savecolor;
    }
    void Awake()
    {
        gm = FindObjectOfType<GameManager>();
		parent = gameObject;
    }
    private void OnMouseDown(){
        gm.tileclicked(new Coordinate(boardposx,boardposy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
