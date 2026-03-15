using System;
using System.Collections.Generic;
using UnityEngine;
using static Character;

[Serializable]
public struct ClassCard
{
    [HideInInspector] public string m_name;
    public STATS[] m_primaryStats;
    public List<string> m_abilities;

    public ClassCard(string _name, STATS[] _primaryStats, List<string> _abilities)
    {
        m_name = _name;
        m_primaryStats = _primaryStats;
        m_abilities = _abilities;
    }

    public STATS GetMajor()
    {
        return m_primaryStats[0];
    }

    public STATS? GetMinor()
    {
        if (m_primaryStats.Length > 1)
        {
            return m_primaryStats[1];
        }
        else
        {
            return null;
        }
    }
}