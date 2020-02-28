using System;
using TMPro;
using UnityEngine;

public class BuildingView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _lvlUpProductsPrice;
    [SerializeField] private TextMeshProUGUI _lvlUpCreditsPrice;


    public event Action levelUpButtonPressed;

    public void LevelUpButtonPressed()
    {
        levelUpButtonPressed?.Invoke();
    }

    public int level
    {
        set
        {
            _level.text = $"Level {value}";
        }
    }

    public int leveUpProductPrice
    {
        set
        {
            _lvlUpProductsPrice.text = value.ToString();
        }
    }

    public int leveUpCreditPrice
    {
        set
        {
            _lvlUpCreditsPrice.text = value.ToString();
        }
    }
}
