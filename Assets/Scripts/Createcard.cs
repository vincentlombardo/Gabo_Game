using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class Createcard : MonoBehaviour
{
    GameObject parent;
    GameObject base_card;
    GameObject image;
    GameObject hp;
    GameObject attk;
    GameObject q;
    teaminfo colors;
    Card card;
    private Sprite mySprite;
    private SpriteRenderer imagerenderer;
    private SpriteRenderer baserenderer;
    private TextMeshPro hptext;
    private RectTransform hprect;
    private TextMeshPro attktext;
    private RectTransform attkrect;
    private TextMeshPro modtext;
    private RectTransform modrect;
    private BoxCollider attkbox;
    public Text_Attk attkscrpt;
    public Text_Mod modscript;
    public Text_Hp hpscrpt;
    Sprite[] cardslist;
    Sprite newcard;

    public string imagestr {get;set;}

    
    public void init(string imagestr)
    {   
        this.imagestr = imagestr;
        parent = gameObject;
        base_card = new GameObject("Base_Image");
        image = new GameObject("Image");
        hp = new GameObject("HP_Text");
        attk = new GameObject("Attk_Text");
        q = new GameObject("Q_Text");

        base_card.transform.parent = parent.transform;
        base_card.transform.localScale  = new Vector3(0.5026241f,0.4698925f,1);
        image.transform.parent = parent.transform;
        hp.transform.parent = parent.transform;
        attk.transform.parent = parent.transform;
        q.transform.parent = parent.transform;

        baserenderer = base_card.AddComponent<SpriteRenderer>() as SpriteRenderer;
        baserenderer.transform.position = new Vector3(0.142f,-0.009f,1f);
        imagerenderer = image.AddComponent<SpriteRenderer>() as SpriteRenderer;
        image.transform.position =  new Vector3(0.0f, 1.26f,0.0f);
        image.transform.localScale = new Vector3(0.5026241f,0.4698925f,1);

        hptext = hp.AddComponent<TextMeshPro>() as TextMeshPro;
        hprect = hptext.GetComponent<RectTransform>();
        hprect.transform.position = new Vector3(0.8f,0.3f,0.0f);
        hprect.sizeDelta = new Vector2(1.5f,1f);
        hptext.fontSize = 5.0f;
        hptext.color = Color.white;
        hpscrpt = hp.AddComponent<Text_Hp>();
        

        attktext = attk.AddComponent<TextMeshPro>() as TextMeshPro;
        attkrect = attktext.GetComponent<RectTransform>();
        attkrect.transform.position = new Vector3(-0.01f,-0.697f,0f);
        attkrect.sizeDelta = new Vector2(2.4f,.75f);
        attktext.fontSize = 4.0f;
        attkbox = attk.AddComponent<BoxCollider>() as BoxCollider;
        attkbox.size = new Vector2(2.4f,.75f);
        attkscrpt = attk.AddComponent<Text_Attk>();
        

        modtext = q.AddComponent<TextMeshPro>() as TextMeshPro;
        modrect = modtext.GetComponent<RectTransform>();
        modrect.transform.position = new Vector3(0f,-1.7f,0.0f);
        modrect.sizeDelta = new Vector2(2.4f,.75f);
        modtext.fontSize = 3.0f;
        modscript = q.AddComponent<Text_Mod>();


        

        

        baserenderer.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        

    }
   
    public void cardref(Card card){
        card.imagename = imagestr;
        this.card = card;
    }
    public void settext(){
        hpscrpt.settext();
        attkscrpt.settext(0);
        modscript.settext();
    }

    
    void createbasewhenready(AsyncOperationHandle<Sprite[]> handleToCheck)
    { 
        if(handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            cardslist = handleToCheck.Result;
            baserenderer.sprite = cardslist[0];
            
            
        }
    }
    void createimagewhenready(AsyncOperationHandle<Sprite[]> handleToCheck)
    { 
        if(handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            imagerenderer.sprite = handleToCheck.Result[0];
            imagerenderer.color = colors.colorlist[card.team-1];
            
        }
    }

    void Start()
    {
        Debug.Log("createcard_Started");
        colors = FindObjectOfType<teaminfo>();
        this.createbase();
        this.createimage(imagestr);
        this.settext();
        
    }

    private void createimage(string imagestr){
        AsyncOperationHandle<Sprite[]> spriteHandle2 = Addressables.LoadAssetAsync<Sprite[]>(imagestr);
        spriteHandle2.Completed += createimagewhenready;

    }
    private void createbase()
    {
            AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/card_sample.png");
            spriteHandle.Completed += createbasewhenready;
    }
}
