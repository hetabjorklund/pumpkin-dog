using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostCode : MonoBehaviour
{
    private float speed = -1.2f; // negative as the ghost moves from the right side of screen to the left

    void Update()
    {
        // move the ghost
        this.GetComponent<Transform>().Translate(this.speed * Time.deltaTime, 0f, 0f);

        // destroy the ghost if it goes beyond the left edge
        if (this.GetComponent<Transform>().position.x <= -81.39)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player")) // if the ghost hits the player
        {
            // play the sound from AudioSource list's index 2
            GameObject.Find("SoundStorageMain").GetComponents<AudioSource>()[2].Play();

            // reduce the points by one
            GameObject.Find("CodeStorage").GetComponent<pointsCode>().points -= 1;
        }        
    }

}
