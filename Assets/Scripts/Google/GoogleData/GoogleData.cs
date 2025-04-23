using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoogleData", menuName = "Scriptable Objects/GoogleData")]
public class GoogleData : ScriptableObject
{
    public List<GoogleDataEntry> m_entryData;

    public GoogleData()
    {
        m_entryData = new List<GoogleDataEntry>();
    }
}

[Serializable]
public class GoogleDataEntry
{
    [HideInInspector] public string m_name;

    public GoogleDataEntry(string _name)
    {
        m_name = _name;
    }
}
