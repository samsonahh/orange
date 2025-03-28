using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidBody;

    int moveDirection;
    public float speed = 5f;

    public int orangeCount = 0;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveDirection = (int)Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(transform.position + speed * moveDirection * Time.fixedDeltaTime * Vector3.right);
    }

    public void PickupOrange()
    {
        orangeCount++;
    }
}
