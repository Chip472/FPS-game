using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowControl : MonoBehaviour
{
    public GameObject player;

    float distanceCPx;
    float distanceCPz;

    private void Start()
    {
        distanceCPx = player.transform.position.x - transform.position.x;
        distanceCPz = player.transform.position.z - transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x - distanceCPx, transform.position.y, player.transform.position.z - distanceCPz);
    }
}
