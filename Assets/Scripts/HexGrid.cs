using Sirenix.OdinInspector;
using UnityEngine;



public class HexGrid : MonoBehaviour
{


	public Vector2Int size;



	[SerializeField]
	private HexCell _cellPrefab;
	private HexCell[] _cells;
	private HexMesh _hexMesh;


	[Button]
	private void Generate()
	{
		if (_cells != null)
		{
			Clear();
			_cells = null;
		}
		_cells = new HexCell[size.x * size.y];

		for (int i = 0, index = 0; i < size.x; i++)
		{
			for (var j = 0; j < size.y; j++)
			{
				_cells[index++] = CreateCell(i, j);
			}
		}

		_hexMesh = GetComponentInChildren<HexMesh>();
		_hexMesh.Init();
		_hexMesh.Triangulate(_cells);
	}


	private HexCell CreateCell(int x, int z)
	{
		// ReSharper disable once PossibleLossOfFraction
		var pos = new Vector3(
			(x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2.0f), 
			0.0f, 
			z * (HexMetrics.outerRadius * 1.5f));

		var cell = Instantiate(_cellPrefab, pos, Quaternion.identity, transform);
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);
		cell.label = cell.coordinates.ToOnStringSeparateLines();

		return cell;
	}


	private void Clear()
	{
		foreach (var cell in _cells)
			if(cell != null)
				DestroyImmediate(cell.gameObject);
	}


	


}
