using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
	[SerializeField] private Transform _baseView;
	[SerializeField] private House _originalHouse;
	[SerializeField] private Factory _originalFactory;
	[SerializeField] private GameObject _buildingsParent;
	[SerializeField] private Barak _barak;
	[SerializeField] private Walls _walls;
	[SerializeField] private Portal _portal;
	[SerializeField] private Map _map;

	private const int _expansionPopulationPrice = 500;
	private const int _expansionProductsPrice = 1000;
	private const int _expansionCreditsPrice = 1000;

	private GameManager gm => GameManager.Instance;


	private void Start()
	{
		Debug.Log("GameStart");
	}


	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space) && 
			gm.products >= _expansionProductsPrice && 
			gm.credits >= _expansionCreditsPrice && 
			gm.population >= _expansionPopulationPrice)
		{
			if (_map.TryBuyCell())
			{
				gm.population -= _expansionPopulationPrice;
				gm.products -= _expansionProductsPrice;
				gm.credits -= _expansionCreditsPrice;

				ExpantedBase();

				_walls.LevelDown(5);

				Debug.Log($"Base expansion, Houses and Factory added. Popelation limit = {gm.populationLimit}, units limit = {_barak.unitsLimit}");
			}
		}
	}

	private void ExpantedBase()
	{
		Building<BuildingView>.Spawn(_originalHouse, this.transform, _baseView);
		Building<BuildingView>.Spawn(_originalFactory, this.transform, _baseView);

		gm.populationLimit += 1000;
		_barak.unitsLimit += 200;
	}
}
