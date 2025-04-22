using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoogleSheetData", menuName = "Scriptable Objects/GoogleSheetData")]
public class GoogleSheetData : ScriptableObject
{
    public List<GoogleSheetEntry> m_entryData;

    public GoogleSheetData()
    {
        m_entryData = new List<GoogleSheetEntry>();
    }
}

[Serializable]
public struct GoogleSheetEntry
{
    public string m_name;
    public List<GoogleSheetColumn> _column;

    public GoogleSheetEntry(string _name)
    {
        m_name = _name;
        _column = new List<GoogleSheetColumn>();
    }
}

[Serializable]
public struct GoogleSheetColumn
{
    public string m_name;
    public string m_data;

    public GoogleSheetColumn(string _name, string _data)
    {
        m_name = _name;
        m_data = _data;
    }
}
