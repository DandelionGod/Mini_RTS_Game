﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BarrackView : BuildingView
{
    [SerializeField] private TextMeshProUGUI _spawnUnitsCout;
    [SerializeField] private Button _trainFastUnitButton;
    [SerializeField] private Button _trainAttackingUnitButton;
    [SerializeField] private Button _trainArmoredUnitButton;
    [SerializeField] private TMP_InputField _trainUnitInputField;
    [SerializeField] private Image _trainUnitButtonFill;

    public string spawnUnitsCount => 
        _spawnUnitsCout.text.Substring(0, Math.Max(0, _spawnUnitsCout.textInfo.characterCount - 1));

    public event Action spawnFastUnitButtonPressed;
    public event Action spawnAttackingUnitButtonPressed;
    public event Action spawnArmoredUnitButtonPressed;


    public void SpawnFastUnitButtonPressed()
    {
        spawnFastUnitButtonPressed?.Invoke();
    }

    public void SpawnAttackingUnitButtonPressed()
    {
        spawnAttackingUnitButtonPressed?.Invoke();
    }

    public void SpawnArmoredUnitButtonPressed()
    {
        spawnArmoredUnitButtonPressed?.Invoke();
    }

    public bool _trainUnitButtonInterractive
    {
        set
        {
            _trainFastUnitButton.interactable = value;
            _trainAttackingUnitButton.interactable = value;
            _trainArmoredUnitButton.interactable = value;
            _trainUnitInputField.interactable = value;
            _trainUnitButtonFill.enabled = !value;
        }
    }

    public float _trainUnitProgressValue
    {
        set
        {
            _trainUnitButtonFill.fillAmount = 1.0f - value;
        }
    }
}
