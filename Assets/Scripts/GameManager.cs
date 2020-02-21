using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{

	static public GameManager Instance;

	[SerializeField] private TextMeshProUGUI _populationView;
	[SerializeField] private TextMeshProUGUI _productsView;
	[SerializeField] private TextMeshProUGUI _creditsView;

	private float _gs = 0;
	private const float _GS = 1;

	public int countGs { private set; get; } = -1;
	public int population { set; get; } = 200;
	public int products { set; get; } = 300;
	public float credits { set; get; } = 500;
	public int populationLimit { set; get; } = 1000;
	public int populationPlus { set; get; } = 100;
	public float productsPlus { set; get; } = 100;
	public float creditPlus { set; get; } = 0.1f;


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("Singleton allready initialized!", Instance);
		}
	}


	void Start()
	{
		Debug.Log("GameStart");
	}


	public void OnValCh(string value)
	{
		Debug.Log(value);
	}


	void Update()
	{
		if (_gs >= _GS)
		{
			if (population + populationPlus <= populationLimit)
				population += populationPlus;
			else
				population += populationLimit - population;
			products += Mathf.RoundToInt(productsPlus);
			credits += population * creditPlus;
			_gs = 0.0f;
			countGs++;
		}

		_populationView.text = $"{population}";
		_productsView.text = $"{products}";
		_creditsView.text = $"{credits}";

		_gs += Time.deltaTime;

	}

}
