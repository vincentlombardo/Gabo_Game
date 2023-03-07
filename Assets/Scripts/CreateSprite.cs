using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CreateSprite : MonoBehaviour
{
   
    public Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;
    private BoxCollider box;
    Sprite[] cardslist;
    Sprite newcard;
    bool spritecomplete = false;
    
    void Awake()
    {
        tex =  Texture2D.blackTexture;
        sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        box = gameObject.AddComponent<BoxCollider>() as BoxCollider;
        

        sr.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        transform.position = new Vector3(1.75f, 2.0f, 0.0f);

    }
   

    void LoadSpritesWhenReady(AsyncOperationHandle<Sprite[]> handleToCheck)
    { 
        if(handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            cardslist = handleToCheck.Result;
            sr.sprite = cardslist[Random.Range(0,2)];
            UnityEngine.Debug.Log("created Sprite");
            spritecomplete = true;
            UnityEngine.Debug.Log(spritecomplete);
            UnityEngine.Debug.Log("is complete ^^");
            Vector2 S = sr.sprite.bounds.size;
            box.size = S;
            UnityEngine.Debug.Log("New Collider is set");
        }
    }

    void Start()
    {
        mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        this.createnewcard();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Add sprite"))  {
            AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/TestCards.png");
            spriteHandle.Completed += LoadSpritesWhenReady;
            
            UnityEngine.Debug.Log(sr.isVisible);
            
        }
    }
    public void createnewcard()
    {
            AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>("Assets/TestCards.png");
            spriteHandle.Completed += LoadSpritesWhenReady;
            
            UnityEngine.Debug.Log(sr.isVisible);
            UnityEngine.Debug.Log(sr.isVisible);

    }
}