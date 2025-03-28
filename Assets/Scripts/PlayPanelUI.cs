using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayPanelUI : MonoBehaviour
{
    [Header("Scene References")]
    public OrangePicker orangePicker;

    [Header("References")]
    public TMP_Text orangeCountText;

    private void Update()
    {
        orangeCountText.text = $"{orangePicker.orangeCount}";
    }
}
