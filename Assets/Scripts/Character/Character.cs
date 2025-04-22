using System;
using UnityEngine;

/// <summary>
/// The data of a character.
/// </summary>
[Serializable]
public struct Character
{
    public enum STATS { STR, DEX, CON, INT, WIS, CHA, TOTAL };

    public string name;
    public int[] stats;

    private CharacterSheet characterSheet;

    public Character(CharacterSheet _charSheetPrefab, Transform _uiBackground)
    {
        name = "newChar";
        stats = new int[6];

        characterSheet = GameObject.Instantiate(_charSheetPrefab, _uiBackground);
    }

    public void ShowCharacter()
    {
        characterSheet.name.text = name;

        for (int i = 0; i < stats.Length; i++)
        {
            characterSheet.stats.text =
                "STR: " + stats[(int)STATS.STR] + GetStatMod(stats[(int)STATS.STR]) + "\n" +
                "DEX: " + stats[(int)STATS.DEX] + GetStatMod(stats[(int)STATS.DEX]) + "\n" +
                "CON: " + stats[(int)STATS.CON] + GetStatMod(stats[(int)STATS.CON]) + "\n" +
                "INT: " + stats[(int)STATS.INT] + GetStatMod(stats[(int)STATS.INT]) + "\n" +
                "WIS: " + stats[(int)STATS.WIS] + GetStatMod(stats[(int)STATS.WIS]) + "\n" +
                "CHA: " + stats[(int)STATS.CHA] + GetStatMod(stats[(int)STATS.CHA]);
        }
    }

    public string GetStatMod(int _stat)
    {
        int moddedStat = (_stat / 2) - 5;

        string moddedStatString = "(";

        if (moddedStat >= 0)
        {
            moddedStatString += "+";
        }

        return moddedStatString + moddedStat + ")";
    }
}