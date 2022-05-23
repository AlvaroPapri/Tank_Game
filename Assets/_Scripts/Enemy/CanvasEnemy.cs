using System;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
