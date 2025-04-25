using System;
using System.Collections.Generic;
using UnityEngine;
using static Character;

[Serializable]
public struct Class
{
    [HideInInspector] public string m_name;
    public STATS[] m_primaryStats;
    public List<string> m_abilities;

    public Class(string _name, STATS[] _primaryStats, List<string> _abilities)
    {
        m_name = _name;
        m_primaryStats = _primaryStats;
        m_abilities = _abilities;
    }


    public static List<Class> RollRandomClasses(GoogleDocData _classData, Character _character)
    {
        List<Class> classes = new List<Class>();

        int level = _character.m_level;
        List<int> positiveStats = new List<int>();
        int positiveStatValue = 12;

        for (int i = 0; i < _character.m_stats.Length; i++)
        {
            if (_character.m_stats[i] >= positiveStatValue)
            {
                positiveStats.Add(i);
            }
        }

        // Roll base class
        int rolledValue = UnityEngine.Random.Range(0, positiveStats.Count);
        classes.Add(GetBaseClassWithStat(_classData, (STATS)positiveStats[rolledValue]));

        List<STATS> rolledValues = new List<STATS>();
        rolledValues.Add((STATS)UnityEngine.Random.Range(0, positiveStats.Count));
        rolledValues.Add((STATS)UnityEngine.Random.Range(0, positiveStats.Count));

        classes.Add(GetCrossClassWithStats(_classData, rolledValues.ToArray()));

        return classes;
    }

    public static Class GetBaseClassWithStat(GoogleDocData _classData, STATS _stats)
    {
        return _classData.m_entryData[0].m_classes[(int)_stats];
    }

    public static Class GetCrossClassWithStats(GoogleDocData _classData, STATS[] _stats)
    {
        if (_stats.Length == 1) // Then we are a base class
        {
            return _classData.m_entryData[0].m_classes[(int)_stats[0]];
        }

        return _classData.m_entryData[(int)_stats[0] + 1].m_classes[(int)_stats[1]];
    }
}