using Sirenix.OdinInspector;
using UnityEngine;



public class HexMapGenerator : MonoBehaviour
{
	[SerializeField] private Mesh _cell;

	[Button]
    private void Generate()
    {
	    Debug.Log("Map Generator Start");

	    _cell = new Mesh {name = "Runtime Cell"};
	    const int CORNERS = 6;
	    var v = new Vector3[CORNERS * 5];
	    var angleOffset = 0.5236f;

		for (var i = 0; i < CORNERS; i++, angleOffset += 6.28319f / (float)CORNERS)
	    {
		    v[i] = new Vector3(Mathf.Cos(angleOffset), 0.0f, Mathf.Sin(angleOffset));
	    }

		_cell.vertices = v;
		_cell.triangles = new [] { 1,2,0,0,2,5,5,2,3,3,4,5 };

		
		for (var i = 0; i < 5; i++)
		{
			for (var j = 0; j < 5; j++)
			{
				var cell = new GameObject($"cell {i} {j}", typeof(MeshFilter), typeof(MeshRenderer));
				cell.GetComponent<MeshFilter>().mesh = _cell;
				cell.transform.position = new Vector3(i * 2 * Mathf.Cos(0.5236f) + (j % 2) * Mathf.Cos(0.5236f), 0, j * 2 * Mathf.Cos(0.5236f));
			}
			
		}
    }


}
