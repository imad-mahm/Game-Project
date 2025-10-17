using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIdleMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float moveAmount = 0.1f;
    public float rotationSpeed = 10f;
    public float rotationAmount = 1f;

    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        transform.position = startPos + new Vector3(
            Mathf.Sin(Time.time * moveSpeed) * moveAmount,
            Mathf.Cos(Time.time * moveSpeed * 0.8f) * moveAmount,
            0
        );

        
        transform.rotation = startRot * Quaternion.Euler(
            Mathf.Sin(Time.time * rotationSpeed) * rotationAmount,
            Mathf.Cos(Time.time * rotationSpeed * 0.7f) * rotationAmount,
            0
        );
    }
}
