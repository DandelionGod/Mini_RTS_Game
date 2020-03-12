using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{


	private Mesh _mesh;
	private List<Vector3> _vertices;
	private List<int> _triangles;



	public void Init()
	{
		_mesh = new Mesh
		{
			name = "Hex Mesh"
		};

		_vertices = new List<Vector3>();
		_triangles = new List<int>();

		GetComponent<MeshFilter>().mesh = _mesh;
	}


	public void Triangulate(HexCell[] cells)
	{
		_mesh.Clear();
		_vertices.Clear();
		_triangles.Clear();

		foreach (var cell in cells)
		{
			Triangulate(cell);
		}

		_mesh.vertices = _vertices.ToArray();
		_mesh.triangles = _triangles.ToArray();
		_mesh.RecalculateNormals();
	}


	private void Triangulate(HexCell cell)
	{
		var center = cell.transform.localPosition;

		for (var i = 0; i < 6; i++)
		{
			AddTriangle(
				center,
				center + HexMetrics.corners[i],
				center + HexMetrics.corners[i + 1]);
		}
	}


	private void AddTriangle(Vector3 v0, Vector3 v1, Vector3 v2)
	{
		var vertexIndex = _vertices.Count;
		_vertices.Add(v0);
		_vertices.Add(v1);
		_vertices.Add(v2);
		_triangles.Add(vertexIndex);
		_triangles.Add(vertexIndex + 1);
		_triangles.Add(vertexIndex + 2);
	}


}
