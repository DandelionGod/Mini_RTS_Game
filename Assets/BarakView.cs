using System;
using TMPro;
using UnityEngine;

public class BarakView : BuildingView
{
    [SerializeField] private TextMeshProUGUI _spawnUnitsCout;

    public string spawnUnitsCount => 
        _spawnUnitsCout.text.Substring(0, _spawnUnitsCout.textInfo.characterCount - 1);

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
}
