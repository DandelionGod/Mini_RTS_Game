using UnityEngine;



public class HexCell : MonoBehaviour
{

	
	public HexCoordinates coordinates;


	[SerializeField]
	private TMPro.TextMeshPro _coords;



	public string label
	{
		get => _coords.text;
		set => _coords.text = value;
	}


}
