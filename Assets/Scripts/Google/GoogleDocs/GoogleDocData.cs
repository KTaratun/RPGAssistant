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
    public List<CharacterClass> m_classes;

    public GoogleDocEntry(string _name) : base(_name)
    {
        m_classes = new List<CharacterClass>();
    }
}

//[Serializable]
//public struct GoogleDocTab
//{
//    [HideInInspector] public string m_name;
//    public List<CharacterClass> m_classes;
//
//    public GoogleDocTab(string _name, List<CharacterClass> _classes)
//    {
//        m_name = _name;
//        m_classes = _classes;
//    }
//}

[Serializable]
public struct CharacterClass
{
    [HideInInspector] public string m_name;
    public List<string> m_abilities;

    public CharacterClass(string _name, List<string> _abilities)
    {
        m_name = _name;
        m_abilities = _abilities;
    }
}