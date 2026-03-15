using RelevantLobster.Variables;
using System.Xml.Linq;
using UnityEngine;
using static Character;

public class Node : MonoBehaviour
{
    [SerializeField] protected StringVariable m_nameVariable;
    [SerializeField] protected StringVariable m_descriptionVariable;
    [SerializeField] protected StringVariable m_primaryStatsVariable;
    [SerializeField] protected StringVariable m_abilitiesVariable;

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

        m_description = _class.m_description;

        m_majorStat = _class.GetMajor();
        m_minorStat = _class.GetMinor();

        m_abilities = new string[_class.m_abilities.Count];
        for (int i = 0; i < m_abilities.Length; i++)
        {
            m_abilities[i] = _class.m_abilities[i];
        }
    }

    public void ButtonClick()
    {
        m_nameVariable.Value = m_name;
        m_descriptionVariable.Value = m_description;

        m_primaryStatsVariable.Value = m_majorStat.ToString();

        if (m_minorStat != null)
        {
            m_primaryStatsVariable.Value += "/" + m_minorStat.ToString();
        }

        m_abilitiesVariable.Value = "";
        for (int i = 0; i < m_abilities.Length; i++)
        {
            m_abilitiesVariable.Value += m_abilities[i];

            if (i != m_abilities.Length - 1)
            {
                m_abilitiesVariable.Value += "\n";
            }    
        }
    }
}