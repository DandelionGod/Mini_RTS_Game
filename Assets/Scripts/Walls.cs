﻿using UnityEngine;


public class Walls : Building
{

	private float _wallDefence = 0.05f;




	protected override void Upgrade()
	{ 
			_wallDefence += 0.05f;
			Debug.Log($"walls defence = {_wallDefence}");
	}


}