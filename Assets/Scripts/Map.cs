using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	[SerializeField] private Transform _cell;
	//[SerializeField] private MeshRenderer _mrCell;


	void Start()
	{
		MapGenerator(15, 15);
		//_mrCell = GetComponent<MeshRenderer>();

		Debug.Log($"Map created");
	}


	void Update()
	{

	}


	public void MapGenerator(int m, int n)
	{
		for (int z = 0; z < n; z++)
		{
			for (int x = 0; x < m; x++)
			{
				Instantiate(_cell, new Vector3(x, 0, z), Quaternion.identity);
			}
		}
	}


	//public void BuyCell()
	//{
	//	if (Input.GetKeyUp(KeyCode.Space))
	//	{
	//		_mrCell.material.color = Color.blue;
	//		Debug.Log("Cell is blue");
	//	}
	//}
}
