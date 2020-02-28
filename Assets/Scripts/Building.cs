
using UnityEngine;



public class Building<T> : MonoBehaviour where T : BuildingView
{

	[SerializeField] protected T _view;

	protected int _level = 1;
	private int _prevLevelUpGs = -1;

	private int _lvlUpProductsPrice = 0;
	private int _lvlUpCreditsPrice = 0;


	protected virtual void Start()
	{
		_lvlUpProductsPrice = CalcLvlUpPrice(1);
		_lvlUpCreditsPrice = _lvlUpProductsPrice;

		_view.leveUpProductPrice = _lvlUpProductsPrice;
		_view.leveUpCreditPrice = _lvlUpCreditsPrice;

		_view.level = _level;
		_view.levelUpButtonPressed += LevelUp;


		Debug.Log("GameStart");

	}


	public static Building<U> Spawn<U>(Building<U> original, Transform parent, Transform viewParent) 
		where U : BuildingView
	{
		var newBuilding = Instantiate(original, parent);
		newBuilding._view = Instantiate(original._view, viewParent);
		return newBuilding;
	}


	private void LevelUp()
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

		_view.leveUpProductPrice = _lvlUpProductsPrice;
		_view.leveUpCreditPrice = _lvlUpCreditsPrice;

		_view.level = _level;
	}


	protected virtual void Upgrade() { }
	protected virtual void Downgrade(int level) { }


	public int CalcLvlUpPrice(int lvl)
	{
		return Mathf.RoundToInt(100 * lvl / 0.985f);
	}

}
