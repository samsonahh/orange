using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;

    public SpriteRenderer spriteRenderer;
    public float leanAngle = 20f;

    [Header("Movement")]
    int moveDirection;
    public float baseSpeed = 5f;

    [Header("Sprinting")]
    public ParticleSystem sprintParticles;
    public float sprintSpeedMultiplier = 2f;
    bool isSprinting;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        sprintParticles.Stop();
    }

    private void Update()
    {
        ReadMoveInput();
        ReadSprintInput();

        AnimateHatLean();
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
        if(isSprinting != Input.GetKey(KeyCode.LeftShift))
        {
            if (isSprinting)
            {
                sprintParticles.Stop();
            }
            else
            {
                sprintParticles.Play();
            }     
        }
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

    void AnimateHatLean()
    {
        bool isMoving = moveDirection != 0;

        if(isMoving)
        {
            float leanDirection = moveDirection > 0 ? 1f : -1f;
            float targetAngle = leanDirection * leanAngle;

            Quaternion targetRotation = Quaternion.Euler(0, 0, 180f - targetAngle);
            spriteRenderer.transform.localRotation = Quaternion.Lerp(spriteRenderer.transform.localRotation, targetRotation, 20f * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 180f);
            spriteRenderer.transform.localRotation = Quaternion.Lerp(spriteRenderer.transform.localRotation, targetRotation, 20f * Time.deltaTime);
        }
    }
}
