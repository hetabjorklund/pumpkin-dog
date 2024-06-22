using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeCode : MonoBehaviour
{ 
    public TimeSpan time = new TimeSpan(0, 0, 0);
    public TimeSpan partime = new TimeSpan(0, 0, 50);
    private GameObject timeTextOnScreen = null;

    void Start()
    {
        this.timeTextOnScreen = GameObject.Find("timeText");
    }
    
    void Update()
    {
        // time progresses and shows up on screen
        this.time = this.time.Add(TimeSpan.FromSeconds(1 * Time.deltaTime));
        this.timeTextOnScreen.GetComponent<Text>().text = "Time: " + this.time.ToString(@"mm\:ss");        

        if (GameObject.Find("CodeStorage").GetComponent<pointsCode>().pumpkinsLeft == 0) 
        {            
             // save time to bring over to the next scene  
            string timespent = this.time.ToString(@"mm\:ss");
            PlayerPrefs.SetString("timespent", timespent);
        }
    }

}