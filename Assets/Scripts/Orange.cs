using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out OrangePicker picker))
        {
            picker.PickupOrange();
            Destroy(gameObject);
        }
    }
}
