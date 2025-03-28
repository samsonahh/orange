using System;
using UnityEngine;

public class OrangePicker : MonoBehaviour
{
    public int orangeCount = 0;

    public Action<int> OnCountIncreased = delegate { };

    public void PickupOrange()
    {
        orangeCount++;
        OnCountIncreased.Invoke(orangeCount);
    }
}
