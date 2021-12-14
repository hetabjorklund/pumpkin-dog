using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverCode : MonoBehaviour
{
    private string timebonustext = "";

    void Start()
    {
        // check if the player got the time bonus
        if (PlayerPrefs.GetInt("timebonus") == 1) {
            this.timebonustext = "You got the time bonus!";
        }
        if (PlayerPrefs.GetInt("timebonus") == 0) {
            this.timebonustext = "You didn't get the time bonus.";
        }

        GameObject.Find("gameOverText").GetComponent<Text>().text = "You got all the pumpkins!\n" + 
        "Your time was " + PlayerPrefs.GetString("timespent") + "\n" + this.timebonustext +
            "\nYour total points are " + PlayerPrefs.GetInt("totalpoints").ToString() + ".";        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            SceneManager.LoadScene(2); // move onto scene in index 2 i.e. the main scene
        }        
    }    
    
}
