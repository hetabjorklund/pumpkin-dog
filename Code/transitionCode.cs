using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionCode : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey) {
            StartCoroutine(GameObject.Find("CodeStorage").GetComponent<sceneManagerCode>().ChangeScene("level2"));
        }
    }
    
}
