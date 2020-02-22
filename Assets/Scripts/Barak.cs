using UnityEngine;

public class Barak : Building
{

	public int unitsLimit { get; set; } = 100;
	private float _unitsAttack = 0.1f;
	private float _unitsArmor = 0.1f;


	protected override void Upgrade()
	{
		unitsLimit += 100;
		_unitsAttack += 0.1f;
		_unitsArmor += 0.1f;

		Debug.Log($"units limit = {unitsLimit}, units attack = {_unitsAttack}, units defence = {_unitsArmor}");
	}

	public void SpawnFastUnit()
	{

	}
}
