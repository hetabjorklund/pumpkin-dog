using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManagerCode : MonoBehaviour
{
    int currentSceneIndex = -1;
    int nextSceneIndex = -1;

    void Start()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        this.currentSceneIndex = currentIndex;
        this.nextSceneIndex = currentIndex + 1;
    }

    public IEnumerator ChangeNextScene()
    {
        return this.ChangeScene(this.nextSceneIndex, 1);
    }

    // for changing the scene based on the scene's index
    public IEnumerator ChangeScene(int index, int waitTime = 0) 
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(index);
    }

    // for changing the scene based on the scene's name
    public IEnumerator ChangeScene(string scene, int waitTime = 0)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(scene);
    }
}