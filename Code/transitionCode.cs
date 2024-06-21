using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionCode : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey) {
            SceneManager.LoadScene("level2"); // move onto the level 2 scene
        }
    }
    
}
