using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpkinCode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player")) // if the player hits the pumpkin
        {
            // play the sound from AudioSource list's index 1
            GameObject.Find("SoundStorageMain").GetComponents<AudioSource>()[1].Play();

            // increase the points by one
            GameObject.Find("CodeStorage").GetComponent<pointsCode>().points += 1;

            // reduce the number of pumpkins left by one
            GameObject.Find("CodeStorage").GetComponent<pointsCode>().pumpkinsLeft -= 1;
            Debug.Log("pumpkinsLeft: " + GameObject.Find("CodeStorage").GetComponent<pointsCode>().pumpkinsLeft);

            // destroy the pumpkin
            Destroy(this.gameObject);
        }
    }

}
