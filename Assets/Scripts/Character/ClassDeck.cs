using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Character;

public class ClassDeck
{
    public List<ClassCard> m_baseClasses;
    public List<ClassCard> m_crossClasses;

    public ClassDeck() 
    { 
        m_baseClasses = new List<ClassCard>();
        m_crossClasses = new List<ClassCard>();
    }

    public static ClassDeck RollRandomClasses(GoogleDocData _classData, Character _character)
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
            int statIndex = Random.Range(0, proficientStats.Count);

            crossValues.Add((STATS)proficientStats[statIndex]);

            positiveStats.Remove(proficientStats[statIndex]);
            proficientStats.Remove(proficientStats[statIndex]);
        }
        
        while (crossValues.Count < 2 && positiveStats.Count > 0)
        {
            int statIndex = Random.Range(0, positiveStats.Count);

            crossValues.Add((STATS)positiveStats[statIndex]);

            positiveStats.Remove(positiveStats[statIndex]);
        }

        if (crossValues.Count > 1) 
        {
            classes.m_crossClasses.Add(GetCrossClassWithStats(_classData, crossValues.ToArray()));
        }

        return classes;
    }

    public static ClassCard GetBaseClassWithStat(GoogleDocData _classData, STATS _stats)
    {
        return _classData.m_entryData[0].m_classes[(int)_stats];
    }

    public static ClassCard GetCrossClassWithStats(GoogleDocData _classData, STATS[] _stats)
    {
        if (_stats.Length == 1) // Then we are a base class
        {
            return _classData.m_entryData[0].m_classes[(int)_stats[0]];
        }

        return _classData.m_entryData[(int)_stats[0] + 1].m_classes[(int)_stats[1]];
    }
}
