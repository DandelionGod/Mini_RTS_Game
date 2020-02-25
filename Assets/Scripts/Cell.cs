using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
	private MeshRenderer _mr;
	static MeshRenderer prev;


	private void OnMouseEnter()
	{
		Debug.Log(name);

	}


	private void OnMouseExit()
	{
		Debug.Log(name);

	}


	private void OnMouseUp()
	{
		if (prev != null)
		{
			prev.material.color = Color.white;
		}

		Debug.Log(name);

		_mr.material.color = Color.green;
		prev = _mr;
	}


	public void BuyCell()
	{
		//if (Input.GetKeyUp(KeyCode.Space) && _mr.material.color == Color.green)
		//{
			_mr.material.color = Color.blue;
			Debug.Log("Cell is blue");
		//}
	}


	void Start()
	{
		_mr = GetComponent<MeshRenderer>();
	}


	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space) && _mr.material.color == Color.green)
		{
			BuyCell();
		}
	}
}
