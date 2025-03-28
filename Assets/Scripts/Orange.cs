using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orange : MonoBehaviour
{
    Rigidbody2D rigidBody;
    CircleCollider2D circleCollider;

    public SpriteRenderer spriteRenderer;
    public List<Sprite> sprites = new();

    public Vector2 rotationSpeedRange = new Vector2(20f, 50f);
    float currentRotationSpeed;
    int rotationDirection;

    public static System.Action OnGroundTouched;

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
            GetPickedUp(0.3f);
            return;
        }

        if(collision.CompareTag("Ground"))
        {
            OnGroundTouched.Invoke();
            GetPickedUp(0.1f);
        }
    }

    void GetPickedUp(float duration)
    {
        circleCollider.enabled = false;
        rigidBody.simulated = false;

        transform.DOScale(Vector3.zero, duration).SetEase(Ease.InBack).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
