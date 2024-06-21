using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introCode : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("SoundStorageIntro")); // the background music from the intro scene continues for the whole game
    }

    void Update()
    {
        if (Input.anyKey) {
            SceneManager.LoadScene("infoscene"); // move onto the info scene
        }        
    }
    
}
