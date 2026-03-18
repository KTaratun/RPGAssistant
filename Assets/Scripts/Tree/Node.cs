using RelevantLobster.Variables;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Character;

public class Node : MonoBehaviour
{
    [SerializeField] protected STATS m_stat;
    [SerializeField] protected StringVariable m_nameVariable;
    [SerializeField] protected StringVariable m_descriptionVariable;
    [SerializeField] protected StringVariable m_primaryStatsVariable;
    [SerializeField] protected StringVariable m_abilitiesVariable;

    protected string m_name;

    protected string m_description;

    protected STATS[] m_majorMinor;

    protected string[] m_abilities;

    protected Button m_button;

    protected TextMeshPro m_text;

    void Awake()
    {
        m_button = GetComponentInChildren<Button>();
        m_text = GetComponentInChildren<TextMeshPro>();
    }

    public void PopulateClassData(ClassCard _class, Character _character, bool _isRoot)
    {
        m_name = _class.m_name;
        
        m_description = _class.m_description;
        
        m_majorMinor = _class.m_primaryStats;
        
        m_abilities = new string[_class.m_abilities.Count];
        for (int i = 0; i < m_abilities.Length; i++)
        {
            m_abilities[i] = _class.m_abilities[i];
        }

        if (!_isRoot && _character.CheckIfHasClass(m_name))
        {
            m_button.image.color = Color.cyan;
        }
        else if (_character.CheckIfHasClass(m_name) && m_majorMinor.Length == 2 
            && m_majorMinor[0] == m_majorMinor[1])
        {
            m_button.image.color += new Color(.3f, .3f, .3f, 0);
        }
        else if (!_character.CheckIfIsUnlockable(m_majorMinor))
        {
            m_button.image.color = Color.gray;
        }
        //else if (!_isRoot && _character.CheckIfIsUnlockable(m_majorMinor))
        //{
        //    m_button.image.color = new Color(.8f, .8f, .8f);
        //}

        if (_isRoot)
        {
            int statIndexFromText = (int)Enum.Parse(typeof(STATS), m_stat.ToString());
            m_text.text = _character.m_stats[statIndexFromText].ToString();
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