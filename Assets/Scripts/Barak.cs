using UnityEngine;


public class Barak : Building
{

	private int _unitsLimit = 100;
	private float _unitsAttack = 0.1f;
	private float _unitsArmor = 0.1f;


	protected override void Upgrade()
	{
		_unitsLimit += 100;
		_unitsAttack += 0.1f;
		_unitsArmor += 0.1f;

		Debug.Log($"units limit = {_unitsLimit}, units attack = {_unitsAttack}, units defence = {_unitsArmor}");
	}


}
