using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointsCode : MonoBehaviour
{ 
    public int points = 0;
    private int pumpkinsTotal = 35;
    public int pumpkinsLeft = 35; 
    private int timebonus = 0;
    private GameObject pointsTextOnScreen = null;

    void Start()
    {
        this.pointsTextOnScreen = GameObject.Find("pointsText");
    }

    void Update()
    {
        Debug.Log("this.pumpkinsLeft" + this.pumpkinsLeft);
        Debug.Log("this.pumpkinsTotal" + this.pumpkinsTotal);
        Debug.Log("this.points" + this.points);

        // points show up on screen       
        this.pointsTextOnScreen.GetComponent<Text>().text = "Points: " + this.points.ToString() + "/" + this.pumpkinsTotal.ToString();        

        // after all pumpkins have been gathered, check if the player beat par time and gets the time bonus
        // save the time bonus information to bring over to the gameover scene
        if (this.pumpkinsLeft == 0) {
            if (GameObject.Find("CodeStorage").GetComponent<timeCode>().time < GameObject.Find("CodeStorage").GetComponent<timeCode>().partime) {
                this.timebonus = 15; 
                PlayerPrefs.SetInt("timebonus", 1);
            } else {
                PlayerPrefs.SetInt("timebonus", 0);                
            }

            // save points to bring over to the next scene        
            PlayerPrefs.SetInt("totalpoints", this.points + this.timebonus);

            // set pumpkinsLeft as something else than 0 so that the if-condition stops being true and the if-loop stops running during the delay
            this.pumpkinsLeft = -1;

            // move onto the next scene
            StartCoroutine(GameObject.Find("CodeStorage").GetComponent<sceneManagerCode>().ChangeNextScene());
        }       
    }

}

