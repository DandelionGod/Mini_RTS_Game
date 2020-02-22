using TMPro;
using UnityEngine;

public class Portal : Building
{

	[SerializeField] private TextMeshProUGUI _goodsForSellCoutView;

	private float _deltaSell = 0.5f;
	private float _deltaBuy = 1.5f;

	private GameManager gm => GameManager.Instance;


	protected override void Upgrade()
	{
		_deltaSell += 0.5f;
		_deltaBuy -= 0.5f;
		gm.productsPlus += gm.productsPlus * 0.0025f;
		gm.creditPlus += 0.0025f;
		Debug.Log($"delta sell = {_deltaSell}, delta buy = {_deltaBuy}, product plus = {gm.productsPlus}, credit plus = {gm.creditPlus}");
	}


	public void SellGoods()
	{
		Debug.Log("Sell");
		if (int.TryParse(_goodsForSellCoutView.text.Substring(0, _goodsForSellCoutView.textInfo.characterCount - 1), out int result))
		{
			Debug.Log($"Sell {result} products and recived {result * _deltaSell} credist");
			gm.products -= result;
			gm.credits += result * _deltaSell;
		}

	}


	public void BuyGoods()
	{
		Debug.Log("Buy");
		if (int.TryParse(_goodsForSellCoutView.text.Substring(0, _goodsForSellCoutView.textInfo.characterCount - 1), out int result))
		{
			Debug.Log($"Buy {result} products and paid {result * _deltaBuy} credits");
			gm.products += result;
			gm.credits -= result * _deltaBuy;
		}
	}

}
