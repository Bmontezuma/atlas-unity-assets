using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Weapon properties
[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _range;

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

// Weapon creation window
public class WeaponCreation : EditorWindow
{
    private Weapon _newWeapon;

    [MenuItem("Custom/Weapon Creation")]
    public static void ShowWindow()
    {
        GetWindow<WeaponCreation>("Weapon Creation");
    }

    private void OnGUI()
    {
        _newWeapon = EditorGUILayout.ObjectField("New Weapon", _newWeapon, typeof(Weapon), false) as Weapon;

        if (GUILayout.Button("Create Weapon"))
        {
            if (_newWeapon != null)
            {
                // Handle creation logic (e.g., saving the asset)
                AssetDatabase.CreateAsset(_newWeapon, "Assets/Items/Weapons/NewWeapon.asset");
                AssetDatabase.SaveAssets();
                Debug.Log("Weapon created!");
            }
            else
            {
                Debug.LogWarning("Please assign a valid weapon.");
            }
        }
    }
}
