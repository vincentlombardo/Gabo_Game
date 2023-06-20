using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaminfo : MonoBehaviour
{
    public Color c1;
    public Color c2;
    public Color c3;
    public Color c4;
    public Color c5;
    public List<Color> colorlist {get;set;}
    // Start is called before the first frame update
    void Awake(){
        colorlist = new List<Color>();
        colorlist.Add(c1);
        colorlist.Add(c2);
        colorlist.Add(c3);
        colorlist.Add(c4);
        colorlist.Add(c5);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
