using RelevantLobster.Variables;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Character;

public class Node : MonoBehaviour
{
    [SerializeField] protected StringVariable m_nameVariable;
    [SerializeField] protected StringVariable m_descriptionVariable;
    [SerializeField] protected StringVariable m_primaryStatsVariable;
    [SerializeField] protected StringVariable m_abilitiesVariable;

    protected string m_name;

    protected string m_description;

    protected STATS[] m_majorMinor;

    protected string[] m_abilities;

    protected Button m_button;

    void Awake()
    {
        m_button = GetComponentInChildren<Button>();
    }

    public void PopulateClassData(ClassCard _class, Character _character)
    {
        m_name = _class.m_name;

        m_description = _class.m_description;

        m_majorMinor = _class.m_primaryStats;

        m_abilities = new string[_class.m_abilities.Count];
        for (int i = 0; i < m_abilities.Length; i++)
        {
            m_abilities[i] = _class.m_abilities[i];
        }

        if (_character.CheckIfHasClass(m_name))
        {
            m_button.image.color = Color.cyan;
        }
        else if (_character.CheckIfIsProficient(m_majorMinor))
        {
            m_button.image.color = Color.yellow;
        }
    }

    public void ButtonClick()
    {
        m_nameVariable.Value = m_name;
        m_descriptionVariable.Value = m_description;

        m_primaryStatsVariable.Value = m_majorMinor[0].ToString();

        if (m_majorMinor.Length > 1)
        {
            m_primaryStatsVariable.Value += "/" + m_majorMinor[1].ToString();
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