using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

/// <summary>
/// The data of a character.
/// </summary>
[Serializable]
public class Character
{
    public enum STATS { STR, DEX, CON, INT, WIS, CHA, TOTAL };
    public enum STAT_VALUES { NEGATIVE = 9, NEUTRAL = 10, POSITIVE = 12, PROFICIENT = 14 };

    public string m_name;
    public int[] m_stats;
    public int m_level;
    public Race m_race;
    public ClassDeck m_classes;

    private CharacterSheet characterSheet;

    public Character()
    {
        m_name = "newChar";
        m_stats = new int[6];
        m_level = 1;
        m_race = new Race();

        characterSheet = GameObject.Find("CharacterSheet").GetComponent<CharacterSheet>();
    }

    public void ShowCharacter()
    {
        characterSheet.m_name.text = m_name;
        characterSheet.m_quirk.text = m_name;
        characterSheet.m_race.text = m_race.m_name;

        if (m_classes.m_crossClasses.Count > 0)
        {
            characterSheet.m_class.text = m_classes.m_crossClasses[0].m_name;
        }
        else
        {
            characterSheet.m_class.text = m_classes.m_baseClasses[0].m_name;
        }

        for (int i = 0; i < m_stats.Length; i++)
        {
            characterSheet.m_modifiers[i].text = GetStatMod(m_stats[i]);
            characterSheet.m_abilityScore[i].text = m_stats[i].ToString();
        }
    }

    public string GetStatMod(int _stat)
    {
        int moddedStat = (_stat / 2) - 5;

        string moddedStatString = "";

        if (moddedStat >= 0)
        {
            moddedStatString += "+";
        }

        return moddedStatString + moddedStat;
    }

    public List<int> GetStatsWithValue(STAT_VALUES _statValue)
    {
        List<int> statsWithValue = new List<int>();
        int statValueAsInt = (int)_statValue;

        for (int i = 0; i < m_stats.Length; i++)
        {
            if (_statValue >= STAT_VALUES.POSITIVE && m_stats[i] >= statValueAsInt ||
                _statValue == STAT_VALUES.NEUTRAL && m_stats[i] >= 10 && m_stats[i] < 12 ||
                _statValue <= STAT_VALUES.NEGATIVE && m_stats[i] <= statValueAsInt)
            {
                statsWithValue.Add(i);
            }
        }

        return statsWithValue;
    }
}