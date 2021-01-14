using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private Text _levelText;
    private void OnEnable()
    {
        GameManager.onLevelChanged += UpdateLevelText;
    }

    private void OnDisable()
    {
        GameManager.onLevelChanged -= UpdateLevelText; 
    }

    private void Awake()
    {
        _levelText = GameObject.Find("Level Text").GetComponent<Text>();
    }

    private void UpdateLevelText(int level)
    {
        _levelText.text = level.ToString();
    }
}
