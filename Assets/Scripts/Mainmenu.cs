using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mainmenu : MonoBehaviour
{
    public AudioMixer master;
    public GameManager gm;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void changevolume(float volume){
        master.SetFloat("Volume",volume);
    }
   
}
