using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointsAndTimeCode : MonoBehaviour
{ 
    private TimeSpan time = new TimeSpan(0, 0, 0);
    private TimeSpan partime = new TimeSpan(0, 0, 50);
    public int points = 0;
    private int pumpkinsTotal = 35;
    public int pumpkinsLeft = 35;
    private int timebonus = 0;
    private GameObject timeTextOnScreen = null;
    private GameObject pointsTextOnScreen = null;

    void Start()
    {
        this.timeTextOnScreen = GameObject.Find("timeText");
        this.pointsTextOnScreen = GameObject.Find("pointsText");
    }

    void Update()
    {
        // time progresses and shows up on screen
        this.time = this.time.Add(TimeSpan.FromSeconds(1 * Time.deltaTime));
        this.timeTextOnScreen.GetComponent<Text>().text = "Time: " + this.time.ToString(@"mm\:ss");        

        // points show up on screen       
        this.pointsTextOnScreen.GetComponent<Text>().text = "Points: " + this.points.ToString() + "/" + this.pumpkinsTotal.ToString();        

        // after all pumpkins have been gathered, check if the player beat par time and gets the time bonus
        // save the time bonus information to bring over to the gameover scene
        if (this.pumpkinsLeft == 0) {
            if (this.time < this.partime) {
                this.timebonus = 15; 
                PlayerPrefs.SetInt("timebonus", 1);
            } else {
                PlayerPrefs.SetInt("timebonus", 0);                
            }

            // save points  to bring over to the gameover scene        
            PlayerPrefs.SetInt("totalpoints", this.points + this.timebonus);

            // save time to bring over to the gameover scene  
            string timespent = this.time.ToString(@"mm\:ss");
            PlayerPrefs.SetString("timespent", timespent);

            // set pumpkinsLeft as something else than 0 so that the if-condition stops being true and the if-loop stops running during the delay
            this.pumpkinsLeft = -1;

            // move onto the gameover scene
            StartCoroutine("ChangeScene"); 
        }       
    }

    IEnumerator ChangeScene() {
        // get the index of current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentSceneIndex + 1;

        // after a 1 second delay, move onto the next scene
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextIndex);
    }

}

