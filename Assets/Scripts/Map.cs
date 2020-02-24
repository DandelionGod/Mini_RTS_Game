using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	[SerializeField] private List<Map> _mapsCells = new List<Map>();
	
	[SerializeField] private Map _originalCell;
	[SerializeField] private GameObject _mapCellsParent;


	void Start()
	{
		MapGenerator(15, 15);
	}


	void Update()
	{

	}


	public void MapGenerator(int n, int m)
	{
		var cell = new Vector3[n, m];
		
		float s = 1;

		for (int j = 0; j < m; j++)
		{
			for (int i = 0; i < n; i++)
			{
				cell[i, j].x = i * s;
				cell[i, j].y = j * s;

				_mapsCells.Add(Instantiate(_originalCell, _mapCellsParent.transform));
				Debug.Log($"cell[{cell[i, j].x}, {cell[i, j].y}]");
			}
		}
	}
}
