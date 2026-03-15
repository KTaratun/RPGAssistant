using System.Xml.Linq;
using UnityEngine;
using static Character;

public class Node : MonoBehaviour
{
    protected string m_name;

    protected string m_description;

    protected STATS m_majorStat;
    protected STATS? m_minorStat;

    protected string[] m_abilities;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void PopulateClassData(ClassCard _class)
    {
        m_name = _class.m_name;

        //m_description = _class

        m_majorStat = _class.GetMajor();
        m_minorStat = _class.GetMinor();

        m_abilities = new string[_class.m_abilities.Count];
        for (int i = 0; i < m_abilities.Length; i++)
        {
            m_abilities[i] = _class.m_abilities[i];
        }
    }
}