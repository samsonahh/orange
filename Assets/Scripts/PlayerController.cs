using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    [Header("Movement")]
    int moveDirection;
    public float baseSpeed = 5f;

    [Header("Sprinting")]
    public float sprintSpeedMultiplier = 2f;
    bool isSprinting;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMoveInput();
        ReadSprintInput();
    }

    private void FixedUpdate()
    {
        ApplyMove();
    }

    void ReadMoveInput()
    {
        moveDirection = (int)Input.GetAxisRaw("Horizontal");
    }

    void ReadSprintInput()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    void ApplyMove()
    {
        float currentSpeed = CalculateCurrentSpeed();
        rigidBody.MovePosition(transform.position + currentSpeed * moveDirection * Time.fixedDeltaTime * Vector3.right);
    }

    float CalculateCurrentSpeed()
    {
        return baseSpeed * (isSprinting ? sprintSpeedMultiplier : 1f);
    }
}
