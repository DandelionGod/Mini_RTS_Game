using System;
using UnityEngine;

public class Map : MonoBehaviour
{
	[SerializeField] private RectTransform _buyCellButton;

	[SerializeField] private Cell _cell;
	private Cell _selectedCell;
	private Cell[,] cells;

	private const int m = 15;
	private const int n = 15;


	void Start()
	{
		MapGenerator(m, n);
		BuyCell(cells[0, 0]);
		Debug.Log($"Map created");
	}


	private void Update()
	{
		if (_selectedCell != null)
		{
			_buyCellButton.gameObject.SetActive(true);

			Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(_selectedCell.transform.position);
			var canvas = (RectTransform)_buyCellButton.parent;
			Vector2 WorldObject_ScreenPosition = new Vector2(
			((ViewportPosition.x * canvas.sizeDelta.x) - (canvas.sizeDelta.x * 0.5f)),
			((ViewportPosition.y * canvas.sizeDelta.y) - (canvas.sizeDelta.y * 0.5f)));

			//now you can set the position of the ui element
			_buyCellButton.anchoredPosition = WorldObject_ScreenPosition;
		}
		else
		{
			_buyCellButton.gameObject.SetActive(false);
		}
	}


	public void MapGenerator(int m, int n)
	{
		cells = new Cell[m, n];
		for (int j = 0; j < n; j++)
		{
			for (int i = 0; i < m; i++)
			{
				cells[i, j] = Instantiate(_cell, new Vector3(i, 0, j), Quaternion.identity);
				cells[i, j].Init(this, i, j);
			}
		}
	}


	public void BuyCell(Cell cell)
	{
		cell.Buy();
	}


	public bool TryBuyCell()
	{
		if (_selectedCell != null && !_selectedCell.isBought && IsHasBoughtNeighbors())
		{
			BuyCell(_selectedCell);
			return true;
		}
		else
			return false;
	}

	private bool IsHasBoughtNeighbors()
	{
		var c = _selectedCell.coords;

		return IsBoughtCell(c + Vector2Int.left) ||
			IsBoughtCell(c + Vector2Int.right) ||
			IsBoughtCell(c + Vector2Int.up) ||
			IsBoughtCell(c + Vector2Int.down);
	}


	private bool IsBoughtCell(Vector2Int coords)
	{
		var c = coords;
		if (c.x >= 0 && c.x <= m && c.y >= 0 && c.y <= n)
			if (cells[c.x, c.y].isBought)
				return true;

		return false;
	}


	public void OnCellMouseUp(Cell cell)
	{
		_selectedCell?.Unselect();
		_selectedCell = cell;
		_selectedCell.Select();
	}



}
