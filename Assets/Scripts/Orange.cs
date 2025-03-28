using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    Rigidbody2D rigidBody;
    CircleCollider2D circleCollider;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites = new();

    public Vector2 rotationSpeedRange = new Vector2(20f, 50f);
    float currentRotationSpeed;
    int rotationDirection;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Count)];

        rotationDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        currentRotationSpeed = Random.Range(rotationSpeedRange.x, rotationSpeedRange.y);
    }

    private void Update()
    {
        spriteRenderer.transform.localRotation = Quaternion.Euler(0, 0, spriteRenderer.transform.localRotation.eulerAngles.z + rotationDirection * currentRotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out OrangePicker picker))
        {
            picker.PickupOrange();
            GetPickedUp();
        }
    }

    void GetPickedUp()
    {
        circleCollider.enabled = false;
        rigidBody.simulated = false;

        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
