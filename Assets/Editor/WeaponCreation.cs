using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Weapon : ScriptableObject
{
    private int _damage;
    private float _attackSpeed;
    private float _range;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
        set { _attackSpeed = value; }
    }

    public float Range
    {
        get { return _range; }
        set { _range = value; }
    }
    // Add any other properties or fields specific to weapons here
}