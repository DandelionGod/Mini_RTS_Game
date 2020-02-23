using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barak : Building
{
	[SerializeField] private List<Unit> _units = new List<Unit>();

	//[SerializeField] private TextMeshProUGUI _levelView;
	[SerializeField] private TextMeshProUGUI _spawnUnitsCoutView;
	[SerializeField] private GameObject _unitsParent;
	[SerializeField] private FastUnit _originalFastUnit;
	[SerializeField] private AttackingUnit _originalAttackingUnit;
	[SerializeField] private ArmoredUnit _originalArmoredUnit;


	public int unitsLimit { get; set; } = 100;
	private float _unitsAttack = 0.1f;
	private float _unitsArmor = 0.1f;
	private int _prevSpawnFastUnitGs = -1;
	private int _prevSpawnAttackingUnitGs = -1;
	private int _prevSpawnArmoredUnitGs = -1;
	private int _productsSpawnUnitPrice = 10;
	private int _creditsSpawnUnitPrice = 10;


	protected override void Upgrade()
	{
		unitsLimit += 100;
		_unitsAttack += 0.1f;
		_unitsArmor += 0.1f;

		Debug.Log($"units limit = {unitsLimit}, units attack = {_unitsAttack}, units defence = {_unitsArmor}");
	}


	public void SpawnFastUnit()
	{
		GameManager gm = GameManager.Instance;
		if (gm.countGs != _prevSpawnFastUnitGs && gm.products >= _productsSpawnUnitPrice && gm.credits >= _creditsSpawnUnitPrice && int.TryParse(_spawnUnitsCoutView.text.Substring(0, _spawnUnitsCoutView.textInfo.characterCount - 1), out int result))
		{
			SpawnUnit(gm, result);

			for (int i = 0; i < result; i++)
			{
				_units.Add(Instantiate(_originalFastUnit, _unitsParent.transform));
			}
		}

	}


	public void SpawnAttackingUnit()
	{
		GameManager gm = GameManager.Instance;
		if (gm.countGs != _prevSpawnAttackingUnitGs && gm.products >= _productsSpawnUnitPrice && gm.credits >= _creditsSpawnUnitPrice && int.TryParse(_spawnUnitsCoutView.text.Substring(0, _spawnUnitsCoutView.textInfo.characterCount - 1), out int result))
		{
			SpawnUnit(gm, result);
			
			for (int i = 0; i < result; i++)
			{
				_units.Add(Instantiate(_originalAttackingUnit, _unitsParent.transform));
			}
		}

	}


	public void SpawnArmoredUnit()
	{
		GameManager gm = GameManager.Instance;
		if (gm.countGs != _prevSpawnArmoredUnitGs && gm.products >= _productsSpawnUnitPrice && gm.credits >= _creditsSpawnUnitPrice && int.TryParse(_spawnUnitsCoutView.text.Substring(0, _spawnUnitsCoutView.textInfo.characterCount - 1), out int result))
		{
			SpawnUnit(gm, result);
			
			for (int i = 0; i < result; i++)
			{
				_units.Add(Instantiate(_originalArmoredUnit, _unitsParent.transform));
			}
		}

	}


	public void SpawnUnit(GameManager gm, int result)
	{
		gm.population -= result;
		gm.products -= _productsSpawnUnitPrice * result;
		gm.credits -= _creditsSpawnUnitPrice * result;
	}
}
