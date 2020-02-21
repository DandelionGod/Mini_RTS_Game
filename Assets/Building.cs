using System;
using TMPro;
using UnityEngine;


public class Building : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _levelView;
	[SerializeField] private TextMeshProUGUI _lvlUpProductsPriceView;
	[SerializeField] private TextMeshProUGUI _lvlUpCreditsPriceView;

	private int _level = 1;

	private int _prevLevelUpGs = -1;
	
	private int _lvlUpProductsPrice = 0;
	private int _lvlUpCreditsPrice = 0;

	private const string _LVLUP = "Lvl up to";



	void Start()
    {
		_lvlUpProductsPrice = CalcLvlUpPrice(1);
		_lvlUpCreditsPrice = _lvlUpProductsPrice;

		_lvlUpProductsPriceView.text = _lvlUpProductsPrice.ToString();
		_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

		Debug.Log("GameStart");

	}


	public void LevelUp()
	{
		GameManager gm = GameManager.Instance;
		if (gm.countGs != _prevLevelUpGs && gm.products >= _lvlUpProductsPrice && gm.credits >= _lvlUpCreditsPrice)
		{
			gm.products -= _lvlUpProductsPrice;
			gm.credits -= _lvlUpCreditsPrice;

			_level++;

			_lvlUpProductsPrice = CalcLvlUpPrice(_level);
			_lvlUpCreditsPrice = _lvlUpProductsPrice;

			_lvlUpProductsPriceView.text = _lvlUpProductsPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_levelView.text = $"{_LVLUP} {_level + 1}";

			Debug.Log($"Level Up to {_level}");

			Upgrade();
		}
	}


	protected virtual void Upgrade() 
	{ }


	public int CalcLvlUpPrice(int lvl)
	{
		return Mathf.RoundToInt(100 * lvl / 0.985f);
	}

}
