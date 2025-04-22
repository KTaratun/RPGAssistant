using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GoogleSheetEntry : GoogleDataEntry
{
    public List<GoogleSheetColumn> _column;

    public GoogleSheetEntry(string _name) : base(_name)
    {
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
