using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostGeneratorCode : MonoBehaviour
{
    public GameObject ghost = null;
    private float timer = 0f;
    private float interval = 4.5f;
    private float cameraPosition = 0f;

    void Start()
    {

    }

    void Update()
    {
        cameraPosition = GameObject.Find("Main Camera").GetComponent<Transform>().position.x;

        this.timer += Time.deltaTime;

        // create new ghost at set time intervals
        if (this.timer >= this.interval) {
            GameObject newGhost = Instantiate(this.ghost,
            new Vector3(cameraPosition + 10.0f, 1.57f, 0f), // new ghost is created a bit to the right from current camera view
            Quaternion.identity);

            this.timer = 0;            
        }
    }
}
