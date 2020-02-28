using System.Collections.Generic;
using UnityEngine;



public class Barak : Building<BarakView>
{
	[SerializeField] private GameObject _unitsParent;
	[SerializeField] private FastUnit _originalFastUnit;
	[SerializeField] private AttackingUnit _originalAttackingUnit;
	[SerializeField] private ArmoredUnit _originalArmoredUnit;
	

	private List<Unit> _units = new List<Unit>();

	private GameManager _gm => GameManager.Instance;
	//private new BarakView _view => base._view as BarakView;


	public int unitsLimit { get; set; } = 100;
	
	private float _unitsAttack = 0.1f;
	private float _unitsArmor = 0.1f;
	private int _prevSpawnFastUnitGs = -1;
	private int _prevSpawnAttackingUnitGs = -1;
	private int _prevSpawnArmoredUnitGs = -1;
	private int _productsSpawnUnitPrice = 10;
	private int _creditsSpawnUnitPrice = 10;



	protected override void Start()
	{
		base.Start();

		_view.spawnFastUnitButtonPressed += SpawnFastUnit;
		_view.spawnAttackingUnitButtonPressed += SpawnAttackingUnit;
		_view.spawnArmoredUnitButtonPressed += SpawnArmoredUnit;
	}


	protected override void Upgrade()
	{
		unitsLimit += 100;
		_unitsAttack += 0.1f;
		_unitsArmor += 0.1f;

		Debug.Log($"units limit = {unitsLimit}, units attack = {_unitsAttack}, units defence = {_unitsArmor}");
	}


	private void SpawnFastUnit()
	{
		if (_gm.countGs != _prevSpawnFastUnitGs)
		{
			SpawnUnit(_originalFastUnit);
			_prevSpawnFastUnitGs = _gm.countGs;
		}
	}


	private void SpawnAttackingUnit()
	{
		if (_gm.countGs != _prevSpawnAttackingUnitGs)
		{
			SpawnUnit(_originalAttackingUnit);
			_prevSpawnAttackingUnitGs = _gm.countGs;

		}
	}


	private void SpawnArmoredUnit()
	{
		if (_gm.countGs != _prevSpawnArmoredUnitGs)
		{
			SpawnUnit(_originalArmoredUnit);
			_prevSpawnArmoredUnitGs = _gm.countGs;
		}
	}


	private void SpawnUnit(Unit unitOriginal)
	{
		
		if (!int.TryParse(_view.spawnUnitsCount, out int uninCount) ||
			_gm.products < _productsSpawnUnitPrice * uninCount ||
			_gm.credits < _creditsSpawnUnitPrice * uninCount)
		{
			return;
		}

		_gm.population -= uninCount;
		_gm.products -= _productsSpawnUnitPrice * uninCount;
		_gm.credits -= _creditsSpawnUnitPrice * uninCount;

		for (int i = 0; i < uninCount; i++)
		{
			_units.Add(Instantiate(unitOriginal, _unitsParent.transform));
		}
	}
}
