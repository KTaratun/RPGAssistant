using System;
using System.Collections.Generic;
using UnityEngine;
using static Character;

[Serializable]
public struct ClassCard
{
    [HideInInspector] public string m_name;
    public string m_description;
    public STATS[] m_primaryStats;
    public List<string> m_abilities;

    public ClassCard(string _name, string _description, STATS[] _primaryStats, List<string> _abilities)
    {
        m_name = _name;
        m_description = _description;
        m_primaryStats = _primaryStats;
        m_abilities = _abilities;
    }
}