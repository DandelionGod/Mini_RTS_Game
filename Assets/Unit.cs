using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected int _speed;
    protected int _attack;
    protected int _armor;

    [SerializeField] private List<Unit> _units = new List<Unit>();


}
