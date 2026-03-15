using System;
using System.Collections.Generic;
using UnityEngine;
using static Character;
using static ClassData;


[Serializable]
public class ClassDeck
{
    public List<ClassCard> m_baseClasses;
    public List<ClassCard> m_crossClasses;

    public ClassDeck() 
    { 
        m_baseClasses = new List<ClassCard>();
        m_crossClasses = new List<ClassCard>();
    }

    public static ClassDeck RollRandomClasses(ClassData _classData, Character _character)
    {
        ClassDeck classes = new ClassDeck();

        int level = _character.m_level;
        List<int> positiveStats = _character.GetStatsWithValue(STAT_VALUES.POSITIVE);
        List<int> proficientStats = _character.GetStatsWithValue(STAT_VALUES.PROFICIENT);

        // Get all base classes
        for (int i = 0; i < proficientStats.Count; i++)
        {
            classes.m_baseClasses.Add(GetBaseClassWithStat(_classData, (STATS)proficientStats[i]));
        }

        List<STATS> crossValues = new List<STATS>();

        while (crossValues.Count < 2 && proficientStats.Count > 0) 
        {
            int statIndex = UnityEngine.Random.Range(0, proficientStats.Count);

            crossValues.Add((STATS)proficientStats[statIndex]);

            positiveStats.Remove(proficientStats[statIndex]);
            proficientStats.Remove(proficientStats[statIndex]);
        }
        
        while (crossValues.Count < 2 && positiveStats.Count > 0)
        {
            int statIndex = UnityEngine.Random.Range(0, positiveStats.Count);

            crossValues.Add((STATS)positiveStats[statIndex]);

            positiveStats.Remove(positiveStats[statIndex]);
        }

        if (crossValues.Count > 1) 
        {
            classes.m_crossClasses.Add(GetCrossClassWithStats(_classData, crossValues.ToArray()));
        }

        return classes;
    }

    public static ClassCard GetBaseClassWithStat(ClassData _classData, STATS _stat)
    {
        return _classData.GetClass(CLASS_PARAMETER.BASE, _stat);
    }

    public static ClassCard GetCrossClassWithStats(ClassData _classData, STATS[] _stats)
    {
        if (_stats.Length == 1) // Then we are a base class
        {
            return _classData.GetClass(CLASS_PARAMETER.BASE, (int)_stats[0]);
        }

        // We add one to the entryData because that list is offset by BASE
        return _classData.GetClass(_stats[0] + 1, _stats[1]);
    }
}