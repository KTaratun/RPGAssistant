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
        characterSheet.m_name.text = "Name: " + m_name;
        characterSheet.m_quirk.text = m_name;
        characterSheet.m_race.text = "Race: " + m_race.m_name;
        characterSheet.m_class.text = "Class: " + m_classes.m_crossClasses[0].m_name;

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
        List<int> positiveStats = new List<int>();
        int statValueAsInt = (int)_statValue;

        for (int i = 0; i < m_stats.Length; i++)
        {
            if (m_stats[i] >= statValueAsInt)
            {
                positiveStats.Add(i);
            }
        }

        return positiveStats;
    }
}