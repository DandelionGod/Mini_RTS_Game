using System;
using UnityEngine;


[Serializable]
public struct HexCoordinates
{
	
	[SerializeField]
	private int _x;
	[SerializeField]
	private int _z;


	public int x => _x;
	public int z => _z;
	public int y => -x - z;



	public HexCoordinates(int x, int z) =>
		(this._x, this._z) = (x, z);


	public static HexCoordinates FromOffsetCoordinates(int x, int z) =>
		new HexCoordinates(x - z / 2, z);


	public override string ToString() =>
		$"({x}, {y}, {z})";


	public string ToOnStringSeparateLines() =>
		$"{x}\n{y}\n{z}";


	public static implicit operator Vector3Int(HexCoordinates c) =>
		new Vector3Int(c.x, c.y, c.z);


}