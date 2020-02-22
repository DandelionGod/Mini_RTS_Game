using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
	[SerializeField] private List<Building> _buildings = new List<Building>();

	[SerializeField] private Building _originalHouses;
	[SerializeField] private Building _originalFactory;
	[SerializeField] private GameObject _buildingsParent;
	[SerializeField] private Barak _barak;
	[SerializeField] private Walls _walls;
	[SerializeField] private Portal _portal;
	[SerializeField] private TextMeshProUGUI _expantionBaseView;

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
		if (Input.GetKeyUp(KeyCode.Space) && gm.products >= _expansionProductsPrice && gm.credits >= _expansionCreditsPrice && gm.population >= _expansionPopulationPrice)
		{
			gm.population -= _expansionPopulationPrice;
			gm.products -= _expansionProductsPrice;
			gm.credits -= _expansionCreditsPrice;

			_buildings.Add(Instantiate(_originalHouses, _buildingsParent.transform));
			_buildings.Add(Instantiate(_originalFactory, _buildingsParent.transform));
			gm.populationLimit += 1000;
			_barak.unitsLimit += 200;

			_walls.LevelDown(5);

			_expantionBaseView.text = "base expantion";
			Debug.Log($"Base expansion, Houses and Factory added. Popelation limit = {gm.populationLimit}, units limit = {_barak.unitsLimit}");
		}
	}

}
