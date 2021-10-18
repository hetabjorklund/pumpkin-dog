using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowCode : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 110.0f;
    private float cameraMinX = -71.95f;
    private float cameraMaxX = 63.95f;

    void Awake() {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    void FixedUpdate() {

        float cameraX = player.position.x;
        float cameraY = transform.position.y;
        float cameraZ = transform.position.z;

        if (player.position.x <= cameraMinX) {
            cameraX = cameraMinX;
        }

        if (player.position.x >= cameraMaxX) {
            cameraX = cameraMaxX;
        }
        
        transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }

}
