using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayPanelUI : MonoBehaviour
{
    [Header("Scene References")]
    public OrangePicker orangePicker;

    [Header("References")]
    public GameObject orangeCounterObject;
    public TMP_Text orangeCountText;

    Vector3 originalOrangeCounterPosition;

    private void Awake()
    {
        originalOrangeCounterPosition = orangeCounterObject.transform.localPosition;
    }

    private void Start()
    {
        orangePicker.OnCountIncreased += OrangePicker_OnCountIncreased;
    }

    private void OnDestroy()
    {
        orangePicker.OnCountIncreased -= OrangePicker_OnCountIncreased;
    }

    private void OrangePicker_OnCountIncreased(int count)
    {
        orangeCountText.text = $"{count}";

        DOTween.Kill(orangeCounterObject);
        orangeCounterObject.transform.localPosition = originalOrangeCounterPosition;
        orangeCounterObject.transform.DOShakePosition(0.5f, 10f);
    }
}
