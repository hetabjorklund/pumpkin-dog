using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class infoCode : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey) {
            SceneManager.LoadScene("level1"); // move onto the level 1 scene
        }
    }
    
}
