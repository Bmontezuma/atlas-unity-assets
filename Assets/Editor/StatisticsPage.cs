using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace MyGame.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : ScriptableObject
    {
        public int attackPower { get; set; }
        public float durability { get; set; }
        public int value { get; set; }
    }

    [CreateAssetMenu(fileName = "New Armor", menuName = "Items/Armor")]
    public class Armor : ScriptableObject
    {
        public int defense { get; set; }
        public float durability { get; set; }
        public int value { get; set; }
    }

    [CreateAssetMenu(fileName = "New Potion", menuName = "Items/Potion")]
    public class Potion : ScriptableObject
    {
        public float baseValue { get; set; }
        public int effectLevel { get; set; }
    }
}

public class StatisticsPage : EditorWindow
{
    private List<MyGame.Items.Weapon> weapons = new List<MyGame.Items.Weapon>();
    private List<MyGame.Items.Armor> armors = new List<MyGame.Items.Armor>();
    private List<MyGame.Items.Potion> potions = new List<MyGame.Items.Potion>();

    [MenuItem("Window/Item Manager/Statistics Page")]
    public static void ShowWindow()
    {
        GetWindow<StatisticsPage>("Item Statistics");
    }

    private void OnEnable()
    {
        LoadItems();
    }

    private void OnGUI()
    {
        GUILayout.Label("General Item Statistics", EditorStyles.boldLabel);
        DrawGeneralStatistics();

        GUILayout.Space(20);

        GUILayout.Label("Weapon Statistics", EditorStyles.boldLabel);
        DrawWeaponStatistics();

        GUILayout.Space(20);

        GUILayout.Label("Armor Statistics", EditorStyles.boldLabel);
        DrawArmorStatistics();

        GUILayout.Space(20);

        GUILayout.Label("Potion Statistics", EditorStyles.boldLabel);
        DrawPotionStatistics();
    }

    private void LoadItems()
    {
        weapons.Clear();
        armors.Clear();
        potions.Clear();

        string[] weaponGuids = AssetDatabase.FindAssets("t:Weapon");
        foreach (string guid in weaponGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            MyGame.Items.Weapon weapon = AssetDatabase.LoadAssetAtPath<MyGame.Items.Weapon>(path);
            weapons.Add(weapon);
        }

        string[] armorGuids = AssetDatabase.FindAssets("t:Armor");
        foreach (string guid in armorGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            MyGame.Items.Armor armor = AssetDatabase.LoadAssetAtPath<MyGame.Items.Armor>(path);
            armors.Add(armor);
        }

        string[] potionGuids = AssetDatabase.FindAssets("t:Potion");
        foreach (string guid in potionGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            MyGame.Items.Potion potion = AssetDatabase.LoadAssetAtPath<MyGame.Items.Potion>(path);
            potions.Add(potion);
        }
    }

    private void DrawGeneralStatistics()
    {
        GUILayout.Label($"Total Items: {weapons.Count + armors.Count + potions.Count}");
        GUILayout.Label($"Total Weapons: {weapons.Count}");
        GUILayout.Label($"Total Armors: {armors.Count}");
        GUILayout.Label($"Total Potions: {potions.Count}");
    }

    private void DrawWeaponStatistics()
    {
        if (weapons.Count == 0) return;

        int totalAttackPower = weapons.Sum(w => w.attackPower);
        float totalDurability = weapons.Sum(w => w.durability);
        int totalValue = weapons.Sum(w => w.value);

        GUILayout.Label($"Average Attack Power: {(float)totalAttackPower / weapons.Count}");
        GUILayout.Label($"Average Durability: {totalDurability / weapons.Count}");
        GUILayout.Label($"Average Value: {(float)totalValue / weapons.Count}");
    }

    private void DrawArmorStatistics()
    {
        if (armors.Count == 0) return;

        int totalDefense = armors.Sum(a => a.defense);
        float totalDurability = armors.Sum(a => a.durability);
        int totalValue = armors.Sum(a => a.value);

        GUILayout.Label($"Average Defense: {(float)totalDefense / armors.Count}");
        GUILayout.Label($"Average Durability: {totalDurability / armors.Count}");
        GUILayout.Label($"Average Value: {(float)totalValue / armors.Count}");
    }

    private void DrawPotionStatistics()
    {
        if (potions.Count == 0) return;

        float totalBaseValue = potions.Sum(p => p.baseValue);
        int totalEffectLevel = potions.Sum(p => p.effectLevel);

        GUILayout.Label($"Average Base Value: {totalBaseValue / potions.Count}");
        GUILayout.Label($"Average Effect Level: {(float)totalEffectLevel / potions.Count}");
    }
}