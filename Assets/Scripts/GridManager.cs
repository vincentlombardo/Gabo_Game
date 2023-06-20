using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width {get;set;}
    public Board card_board;
    public float startingposx = -14.49f;
    public float startingposy = -2.25f;
    public List<List<GameObject>> indicatorboard = new List<List<GameObject>>();
    public int height {get;set;}
    public List<List<Tile>> board = new List<List<Tile>>();
    [SerializeField] public Tile _tilePrefab;
    [SerializeField] public GameObject redblock;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void illuminate(boardrange range,Coordinate pos){
        foreach (var posssquare in range.rangelist){
			int xsquare = posssquare.Item1 + pos.xpos;
			int ysquare =  posssquare.Item2 +pos.ypos;
            if (this.ingrid(new Coordinate(xsquare,ysquare))){
                board[xsquare][ysquare].illuminate();
            }
			
		}

    }
    public void illuminateattk(boardrange range,Coordinate pos){
        foreach (var posssquare in range.rangelist){
			int xsquare = posssquare.Item1 + pos.xpos;
			int ysquare =  posssquare.Item2 +pos.ypos;
            if (this.ingrid(new Coordinate(xsquare,ysquare))){
                indicatorboard[xsquare][ysquare].SetActive(true);
            }
			
		}

    }
    
    public void resetattkcounters(){
        foreach (List<GameObject> row in indicatorboard){
            foreach (GameObject indicator in row){
                indicator.SetActive(false);

            }
        }
    }
    public void resetmoveillum(){
        foreach (List<Tile> row in board){
            foreach (Tile tile in row){
                tile.reset();

            }
        }
        
    }
    public void setimportsquares(boardrange range,int team){
        Coordinate pos = new Coordinate(0,0);
        foreach (var posssquare in range.rangelist){
			int xsquare = posssquare.Item1 + pos.xpos;
			int ysquare =  posssquare.Item2 +pos.ypos;
            if (this.ingrid(new Coordinate(xsquare,ysquare))){
                Debug.Log(string.Format("{0} {1}", xsquare,ysquare));
                Debug.Log(string.Format("{0} {1}", board.Count,board[0].Count));

                board[xsquare][ysquare].setimportsquare(team);
            }
			
		}
    }
    public void sethealthsquares(boardrange range,int team){
        Coordinate pos = new Coordinate(0,0);
        foreach (var posssquare in range.rangelist){
			int xsquare = posssquare.Item1 + pos.xpos;
			int ysquare =  posssquare.Item2 +pos.ypos;
            if (this.ingrid(new Coordinate(xsquare,ysquare))){
                Debug.Log(string.Format("{0} {1}", xsquare,ysquare));
                Debug.Log(string.Format("{0} {1}", board.Count,board[0].Count));

                board[xsquare][ysquare].sethealthsquare(team);
            }
			
		}
    }
    public void init(int wid,int ht, Board board){
        generategrid(wid,ht);
        card_board = board;
    }
    public void generategrid(int wid, int ht){
        this.width = wid;
        this.height = ht;
        for (int x = 0; x<width;x++){
            List<Tile> row = new List<Tile>();
            List<GameObject> indicatorrow = new List<GameObject>();
           for (int y = 0; y<height;y++){
                var newtile = Instantiate(_tilePrefab,new Vector3(startingposx + x*2.555f, startingposy + y*2.555f,1),Quaternion.identity);
                newtile.name = string.Format("Tile {0},{1}",x,y);
                var isoffset = (x%2 ==0 && y%2!=0) || (y%2 ==0 && x%2!=0);
                newtile.init(isoffset,startingposx + x*2.555f, startingposy + y*2.555f,x,y);
                row.Add(newtile);
                var indicator = Instantiate(redblock,new Vector3(newtile.transx, newtile.transy,-1),Quaternion.identity);
                indicator.SetActive(false);
                indicator.name = string.Format("Indicator {0},{1}",x,y);
                indicatorrow.Add(indicator);
            } 
            board.Add(row);
            indicatorboard.Add(indicatorrow);
        }
    }

    public Tile get(Coordinate pos){
		return board[pos.xpos][pos.ypos];
	}
    // Update is called once per frame

    
    void Update()
    {
        if (card_board != null){
            foreach(var row in card_board.board){
            foreach(Card card in row){
                if (card.placeholder != null){
                    card.placeholder.transform.position = new Vector2(board[card.pos.xpos][card.pos.ypos].transx,board[card.pos.xpos][card.pos.ypos].transy);
                }
            }
        }
        }
        
    }

    public bool ingrid(Coordinate pos){
        if(pos.xpos < width && pos.xpos >= 0 && pos.ypos < height && pos.ypos>= 0){
            return true;
        }
        return false;
    }
    
}
