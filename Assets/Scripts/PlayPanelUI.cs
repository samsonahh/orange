using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanelUI : MonoBehaviour
{
    [Header("Scene References")]
    public OrangePicker orangePicker;

    [Header("References")]
    public GameObject orangeCounterObject;
    public TMP_Text orangeCountText;
    public List<Image> heartImages = new();

    Vector3 originalOrangeCounterPosition;
    int lives = 3;

    private void Awake()
    {
        originalOrangeCounterPosition = orangeCounterObject.transform.localPosition;
    }

    private void Start()
    {
        orangePicker.OnCountIncreased += OrangePicker_OnCountIncreased;
        Orange.OnGroundTouched += Orange_OnGroundTouched;
    }

    private void OnDestroy()
    {
        orangePicker.OnCountIncreased -= OrangePicker_OnCountIncreased;
        Orange.OnGroundTouched -= Orange_OnGroundTouched;
    }

    private void OrangePicker_OnCountIncreased(int count)
    {
        orangeCountText.text = $"{count}";

        DOTween.Kill(orangeCounterObject);
        orangeCounterObject.transform.localPosition = originalOrangeCounterPosition;
        orangeCounterObject.transform.DOShakePosition(0.5f, 10f);
    }

    private void Orange_OnGroundTouched()
    {
        lives--;
        for(int i = 0; i < heartImages.Count; i++)
        {
            if (i < lives) heartImages[i].enabled = true;
            else heartImages[i].enabled = false;
        }

        if(lives <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
