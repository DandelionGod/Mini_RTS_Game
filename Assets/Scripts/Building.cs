using TMPro;
using UnityEngine;

public class Building : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI _levelView;
	[SerializeField] private TextMeshProUGUI _nextLevelView;
	[SerializeField] private TextMeshProUGUI _lvlUpProductsPriceView;
	[SerializeField] private TextMeshProUGUI _lvlUpCreditsPriceView;

	protected int _level = 1;
	private int _prevLevelUpGs = -1;
	private const string _LVLUP = "Lvl up to";

	private int _lvlUpProductsPrice = 0;
	private int _lvlUpCreditsPrice = 0;


	void Start()
	{
		_levelView.text = $"Level {_level}";

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

		Debug.Log($"Level Down to {_level}");

		Downgrade(level);
	}


	private void UpdateDataByLevel()
	{
		_lvlUpProductsPrice = CalcLvlUpPrice(_level);
		_lvlUpCreditsPrice = _lvlUpProductsPrice;

		_lvlUpProductsPriceView.text = _lvlUpProductsPrice.ToString();
		_lvlUpCreditsPriceView.text = _lvlUpCreditsPrice.ToString();

		_levelView.text = $"Level {_level}";

		_nextLevelView.text = $"{_LVLUP} {_level + 1}";
	}


	protected virtual void Upgrade() { }
	protected virtual void Downgrade(int level) { }


	public int CalcLvlUpPrice(int lvl)
	{
		return Mathf.RoundToInt(100 * lvl / 0.985f);
	}

}
