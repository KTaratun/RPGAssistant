using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The data of a character.
/// </summary>
[Serializable]
public struct Character
{
    public enum STATS { STR, DEX, CON, INT, WIS, CHA, TOTAL };

    public string m_name;
    public int[] m_stats;
    public int m_level;
    public Race m_race;
    public List<Class> m_classes;

    private CharacterSheet characterSheet;

    public Character(CharacterSheet _charSheetPrefab, Transform _uiBackground)
    {
        m_name = "newChar";
        m_stats = new int[6];
        m_level = 1;
        m_race = new Race();
        m_classes = new List<Class>();

        characterSheet = GameObject.Instantiate(_charSheetPrefab, _uiBackground);
    }

    public void ShowCharacter()
    {
        characterSheet.m_name.text = m_name;

        for (int i = 0; i < m_stats.Length; i++)
        {
            characterSheet.m_stats.text =
                "STR: " + m_stats[(int)STATS.STR] + GetStatMod(m_stats[(int)STATS.STR]) + "\n" +
                "DEX: " + m_stats[(int)STATS.DEX] + GetStatMod(m_stats[(int)STATS.DEX]) + "\n" +
                "CON: " + m_stats[(int)STATS.CON] + GetStatMod(m_stats[(int)STATS.CON]) + "\n" +
                "INT: " + m_stats[(int)STATS.INT] + GetStatMod(m_stats[(int)STATS.INT]) + "\n" +
                "WIS: " + m_stats[(int)STATS.WIS] + GetStatMod(m_stats[(int)STATS.WIS]) + "\n" +
                "CHA: " + m_stats[(int)STATS.CHA] + GetStatMod(m_stats[(int)STATS.CHA]);
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