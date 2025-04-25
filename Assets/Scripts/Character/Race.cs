using System;
using UnityEngine;

[Serializable]
public struct Race
{
    public string m_name;
    public string m_description;

    public Race(string _name, string _description)
    {
        m_name = _name;
        m_description = _description;
    }

    public static Race RollRandomRace(GoogleSheetData _raceData)
    {
        int raceIndex = UnityEngine.Random.Range(0, GetNumberOfRaces(_raceData));

        return GetRaceAtIndex(_raceData, raceIndex);
    }

    public static Race GetRaceAtIndex(GoogleSheetData _raceData, int index)
    {
        GoogleSheetEntry raceEntry = _raceData.m_entryData[index];

        Race raceAtIndex = new Race();
        raceAtIndex.m_name = raceEntry.m_name;
        raceAtIndex.m_description = raceEntry.m_columns[0].m_data;

        return raceAtIndex;
    }

    public static int GetNumberOfRaces(GoogleSheetData _raceData)
    {
        return _raceData.m_entryData.Count;
    }
}