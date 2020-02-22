using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _levelView;
	[SerializeField] private TextMeshProUGUI _lvlUpProductsPriceView;
	[SerializeField] private TextMeshProUGUI _lvlUpCreditsPriceView;

	protected int _level = 1;
	private int _prevLevelUpGs = -1;
	private const string _LVLUP = "Lvl up to";

	public int lvlUpProductsPrice { get; set; } = 0;
	public int lvlUpCreditsPrice { get; set; } = 0;


	void Start()
	{
		lvlUpProductsPrice = CalcLvlUpPrice(1);
		lvlUpCreditsPrice = lvlUpProductsPrice;

		_lvlUpProductsPriceView.text = lvlUpProductsPrice.ToString();
		_lvlUpCreditsPriceView.text = lvlUpCreditsPrice.ToString();

		Debug.Log("GameStart");

	}


	public void LevelUp()
	{
		GameManager gm = GameManager.Instance;
		if (gm.countGs != _prevLevelUpGs && gm.products >= lvlUpProductsPrice && gm.credits >= lvlUpCreditsPrice)
		{
			gm.products -= lvlUpProductsPrice;
			gm.credits -= lvlUpCreditsPrice;

			_level++;

			UpdateDataByLevel();

			Debug.Log($"Level Up to {_level}");

			Upgrade();
		}
	}


	public void LevelDown(int level)
	{
		if (level < _level)
		{
			_level -= level;
		}
		else
		{
			level = _level - 1;
			_level = 1;
		}

		UpdateDataByLevel();

		Downgrade(level);
	}


	private void UpdateDataByLevel()
	{
		lvlUpProductsPrice = CalcLvlUpPrice(_level);
		lvlUpCreditsPrice = lvlUpProductsPrice;

		_lvlUpProductsPriceView.text = lvlUpProductsPrice.ToString();
		_lvlUpCreditsPriceView.text = lvlUpCreditsPrice.ToString();

		_levelView.text = $"{_LVLUP} {_level + 1}";
	}


	protected virtual void Upgrade() { }
	protected virtual void Downgrade(int level)
	{ }


	public int CalcLvlUpPrice(int lvl)
	{
		return Mathf.RoundToInt(100 * lvl / 0.985f);
	}

}
