using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoogleDocData", menuName = "Scriptable Objects/GoogleDocData")]
public class GoogleDocData : ScriptableObject
{
    public List<GoogleDocEntry> m_entryData;

    public GoogleDocData()
    {
        m_entryData = new List<GoogleDocEntry>();
    }
}

[Serializable]
public class GoogleDocEntry : GoogleDataEntry
{
    public List<GoogleDocTab> m_tabs;

    public GoogleDocEntry(string _name) : base(_name)
    {
        m_tabs = new List<GoogleDocTab>();
    }
}

[Serializable]
public struct GoogleDocTab
{
    [HideInInspector] public string m_name;
    public List<Class> m_classes;

    public GoogleDocTab(string _name, List<Class> _classes)
    {
        m_name = _name;
        m_classes = _classes;
    }
}

public struct Class
{
    [HideInInspector] public string m_name;
    public List<string> m_abilities;

    public Class(string _name, List<string> _abilities)
    {
        m_name = _name;
        m_abilities = _abilities;
    }
}