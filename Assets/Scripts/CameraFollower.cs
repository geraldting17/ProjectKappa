using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y , player.position.z + offset.z); // Camera follows the player with specified offset position
    }
}
