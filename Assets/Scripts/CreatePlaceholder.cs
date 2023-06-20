using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class CreatePlaceholder : MonoBehaviour
{
    GameManager gm;
    public Card card;
    public GameObject parent;
    public GameObject image;
    public GameObject hp;
    private SpriteRenderer imagerenderer;
    private TextMeshPro hptext;

    private RectTransform hprect;
    public Text_Hp hpscrpt;
    BoxCollider imagebox;
    teaminfo colors;

    
    
    // Start is called before the first frame update

    public void init(Card card){
        this.card = card;
        card.placeholder = this;
        parent = gameObject;
        image = new GameObject("Image");
        hp = new GameObject("HP_Text");
        imagerenderer = image.AddComponent<SpriteRenderer>() as SpriteRenderer;
        image.transform.parent = parent.transform;
        image.transform.localScale = new Vector3(.5f,.5f,1f);
        hp.transform.parent = parent.transform;
        imagebox = parent.AddComponent<BoxCollider>() as BoxCollider;
        imagebox.size = new Vector2(2.5f,2.5f);
        hptext = hp.AddComponent<TextMeshPro>() as TextMeshPro;
        hprect = hptext.GetComponent<RectTransform>();
        hprect.transform.position = new Vector3(0.8f,-1f,0.0f);
        hprect.sizeDelta = new Vector2(.85f,.3f);
        hptext.fontSize = 3.0f;
        hptext.color = Color.white;
        hpscrpt = hp.AddComponent<Text_Hp>();
        hpscrpt.placeholderinit(card);
        transform.position = new Vector3(-20f, 0f,0.0f);
        parent.SetActive(false);
        
    }
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        colors = FindObjectOfType<teaminfo>();

        this.createimage(card.imagename);
        
        
        
    }

    void createimagewhenready(AsyncOperationHandle<Sprite[]> handleToCheck)
    { 
        if(handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            imagerenderer.sprite = handleToCheck.Result[0];
            imagerenderer.color = colors.colorlist[card.team-1];
            
        }
    }
    private void createimage(string imagename){
        AsyncOperationHandle<Sprite[]> spriteHandle2 = Addressables.LoadAssetAsync<Sprite[]>(imagename);
        spriteHandle2.Completed += createimagewhenready;

    }
    // Update is called once per frame
    void Update()
    {
        if (card.health != null){
            hpscrpt.sethp(card.health);  
        }
        if (card.dead){
            parent.SetActive(false); 
        }
		
    }
    
    private void OnMouseDown(){
        Debug.Log("Placeholder was clicked");
        gm.placeholderclicked(card);
    }
}
