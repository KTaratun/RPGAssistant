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
public class GoogleSheetEntry : GoogleDataEntry
{
    public List<GoogleSheetColumn> m_columns;

    public GoogleSheetEntry(string _name) : base(_name)
    {
        m_columns = new List<GoogleSheetColumn>();
    }
}

[Serializable]
public struct GoogleSheetColumn
{
    [HideInInspector] public string m_name;
    public string m_data;

    public GoogleSheetColumn(string _name, string _data)
    {
        m_name = _name;
        m_data = _data;
    }
}
