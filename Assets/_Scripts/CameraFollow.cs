using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    [Header("Camera Settings")]
    public Vector3 offset;

    private void Update()
    {
        transform.position = player.position + offset;
        transform.LookAt(player.transform.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
