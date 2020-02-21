using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _populationView;
	[SerializeField] private TextMeshProUGUI _productsView;
	[SerializeField] private TextMeshProUGUI _creditsView;
	[SerializeField] private TextMeshProUGUI _textView;
	[SerializeField] private TextMeshProUGUI _lvlBaraksView;
	[SerializeField] private TextMeshProUGUI _lvlHousesView;
	[SerializeField] private TextMeshProUGUI _lvlWallsView;
	[SerializeField] private TextMeshProUGUI _lvlFactoryView;
	[SerializeField] private TextMeshProUGUI _lvlPortalView;
	[SerializeField] private TextMeshProUGUI _lvlUpProductPriceView;
	[SerializeField] private TextMeshProUGUI _lvlUpCreditsPriceView;

	private int _population = 200;
	private int _products = 300;
	private float _credits = 500;
	private int _lvlBaraks = 1;
	private int _lvlHouses = 1;
	private int _lvlWalls = 1;
	private int _lvlFactory = 1;
	private int _lvlPortal = 1;
	private int _countGs = 0;
	private int _prevBaraksLvlUpGs = -1;
	private int _prevHousesLvlUpGs = -1;
	private int _prevWallsLvlUpGs = -1;
	private int _prevFactoryLvlUpGs = -1;
	private int _prevPortalLvlUpGs = -1;
	private float _deltaSell = 0.5f;
	private float _deltaBuy = 1.5f;
	private int _lvlUpProductPrice = 0;
	private int _lvlUpCreditsPrice = 0;

	private const float _GS = 1.0f;
	private int _POPULATION_LIMIT = 1000;
	private int _POPULATION_PLUS = 100;
	private float _PRODUCTS_PLUS = 100;
	private float _creditPlus = 0.1f;
	private const string _LVLUP = "Lvl up to";
	private int _unitsLimit = 100;
	private float _unitsAttack = 0.1f;
	private float _unitsArmor = 0.1f;
	private float _wallDefence = 0.05f;


	private float _gs;



	void Start()
	{
		_lvlUpProductPrice = CalcLvlUpPrice(1);
		_lvlUpCreditsPrice = _lvlUpProductPrice;

		_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
		_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

		Debug.Log("GameStart");
	}

	public void OnValCh(string value)
	{
		Debug.Log(value);
	}

	void Update()
	{
		if (_gs >= _GS)
		{
			if (_population + _POPULATION_PLUS <= _POPULATION_LIMIT)
				_population += _POPULATION_PLUS;
			else
				_population += _POPULATION_LIMIT - _population;
			_products += Mathf.RoundToInt(_PRODUCTS_PLUS);
			_credits += _population * _creditPlus;
			_gs = 0.0f;
			_countGs++;
		}

		_populationView.text = $"{_population}";
		_productsView.text = $"{_products}";
		_creditsView.text = $"{_credits}";

		_gs += Time.deltaTime;

	}


	public void SellGoods()
	{
		Debug.Log("Sell");
		if (int.TryParse(_textView.text.Substring(0, _textView.textInfo.characterCount - 1), out int result))
		{
			Debug.Log($"Sell {result} products and recived {result * _deltaSell} credist");
			_products -= result;
			_credits += result * _deltaSell;
		}

	}

	public void BuyGoods()
	{
		Debug.Log("Buy");
		if (int.TryParse(_textView.text.Substring(0, _textView.textInfo.characterCount - 1), out int result))
		{
			Debug.Log($"Buy {result} products and paid {result * _deltaBuy} credits");
			_products += result;
			_credits -= result * _deltaBuy;
		}
	}

	public void LvlUpBaraks()
	{
		if (_countGs != _prevBaraksLvlUpGs && _products >= _lvlUpProductPrice && _credits >= _lvlUpCreditsPrice)
		{
			_products -= _lvlUpProductPrice;
			_credits -= _lvlUpCreditsPrice;
			
			_lvlBaraks++;

			_lvlUpProductPrice = CalcLvlUpPrice(_lvlBaraks);
			_lvlUpCreditsPrice = _lvlUpProductPrice;

			_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_lvlBaraksView.text = $"{_LVLUP} {_lvlBaraks + 1}";
			_prevBaraksLvlUpGs = _countGs;
			_unitsLimit += 100;
			_unitsAttack += 0.1f;
			_unitsArmor += 0.1f;
			
			Debug.Log($"Lvl Up Baraks to {_lvlBaraks}, units limit = {_unitsLimit}, units attack = {_unitsAttack}, units defence = {_unitsArmor}");
		}
	}

	public void LvlUpHouses()
	{
		if (_countGs != _prevHousesLvlUpGs && _products >= _lvlUpProductPrice && _credits >= _lvlUpCreditsPrice)
		{
			_products -= _lvlUpProductPrice;
			_credits -= _lvlUpCreditsPrice;

			_lvlHouses++;

			_lvlUpProductPrice = CalcLvlUpPrice(_lvlBaraks);
			_lvlUpCreditsPrice = _lvlUpProductPrice;

			_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_lvlHousesView.text = $"{_LVLUP} {_lvlHouses + 1}";
			_POPULATION_LIMIT += 200;
			_POPULATION_PLUS += Mathf.RoundToInt(_POPULATION_PLUS * 0.05f);
			Debug.Log($"Lvl Up Houses to {_lvlHouses}, Population limit = {_POPULATION_LIMIT}, Population plus = {_POPULATION_PLUS}");
		}
	}

	public void LvlUpWalls()
	{
		if (_countGs != _prevWallsLvlUpGs && _products >= _lvlUpProductPrice && _credits >= _lvlUpCreditsPrice)
		{
			_products -= _lvlUpProductPrice;
			_credits -= _lvlUpCreditsPrice;

			_lvlWalls++; _lvlUpProductPrice = CalcLvlUpPrice(_lvlBaraks);
			_lvlUpCreditsPrice = _lvlUpProductPrice;

			_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_lvlWallsView.text = $"{_LVLUP} {_lvlWalls + 1}";
			_wallDefence += 0.05f;
			Debug.Log($"Lvl Up Walls to {_lvlWalls}, wall defence = {_wallDefence}");
		}
	}

	public void LvlUpFactory()
	{
		if (_countGs != _prevFactoryLvlUpGs && _products >= _lvlUpProductPrice && _credits >= _lvlUpCreditsPrice)
		{
			_products -= _lvlUpProductPrice;
			_credits -= _lvlUpCreditsPrice;

			_lvlFactory++; _lvlUpProductPrice = CalcLvlUpPrice(_lvlBaraks);
			_lvlUpCreditsPrice = _lvlUpProductPrice;

			_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_lvlFactoryView.text = $"{_LVLUP} {_lvlFactory + 1}";
			_PRODUCTS_PLUS += _PRODUCTS_PLUS * 0.0175f;
			Debug.Log($"Lvl Up Factory to {_lvlFactory}, product plus = {_PRODUCTS_PLUS}");
		}
	}

	public void LvlUpPortal()
	{
		if (_countGs != _prevPortalLvlUpGs && _products >= _lvlUpProductPrice && _credits >= _lvlUpCreditsPrice)
		{
			_products -= _lvlUpProductPrice;
			_credits -= _lvlUpCreditsPrice;
			
			_lvlPortal++; _lvlUpProductPrice = CalcLvlUpPrice(_lvlBaraks);
			_lvlUpCreditsPrice = _lvlUpProductPrice;

			_lvlUpProductPriceView.text = _lvlUpProductPrice.ToString();
			_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

			_lvlPortalView.text = $"{_LVLUP} {_lvlPortal + 1}";
			_deltaSell += 0.5f;
			_deltaBuy -= 0.5f;
			_PRODUCTS_PLUS += _PRODUCTS_PLUS * 0.0025f;
			_creditPlus += 0.0025f;
			Debug.Log($"Lvl Up Portal to {_lvlPortal}, delta sell = {_deltaSell}, delta buy = {_deltaBuy}, product plus = {_PRODUCTS_PLUS}, credit plus = {_creditPlus}");
		}
	}

	public int CalcLvlUpPrice(int lvl)
	{
		return Mathf.RoundToInt(100 * lvl / 0.985f);
	}
}
