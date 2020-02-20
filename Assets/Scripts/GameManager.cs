using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _populationView;

	private int _population = 200;

	private const float _GS = 1.0f;
	private const int _POPULATION_LIMIT = 1000;
	private const int _POPULATION_PLUS = 100;


	private float _gs;

	

    void Start()
    {
	    Debug.Log("GameStart");
    }


    void Update()
    {
	    if (_gs >= _GS)
	    {
		    if (_population + _POPULATION_PLUS <= _POPULATION_LIMIT)
			    _population += _POPULATION_PLUS;
		    else
			    _population += _POPULATION_LIMIT - _population;

		    _gs = 0.0f;
	    }

	    _populationView.text = $"{_population}";

	    _gs += Time.deltaTime;
    }


}
