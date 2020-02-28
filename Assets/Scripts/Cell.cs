using UnityEngine;



public class Cell : MonoBehaviour
{
	private Map _map;

	private MeshRenderer _mr;
	private bool _isSelected = false;
	public Vector2Int coords { get; private set; }

	public bool isBought { get; private set; } = false;



	internal void Init(Map map, int i, int j)
	{
		_mr = GetComponent<MeshRenderer>();
		_map = map;
		coords = new Vector2Int(i, j);
	}


	private void OnMouseUp()
	{
		_map.OnCellMouseUp(this);
	}


	internal void Unselect()
	{
		_isSelected = false;

		if (!isBought)
			_mr.material.color = Color.white;
	}

	internal void Select()
	{
		_isSelected = true;

		if (!isBought)
			_mr.material.color = Color.green;
	}

	internal void Buy()
	{
		isBought = true;

		_mr.material.color = Color.blue;
	}
}
