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
}