using System;
using System.Collections.Generic;
using UnityEngine;
using RelevantLobster.Signals;

/// <summary>
/// Manages all character related operations.
/// </summary>
[CreateAssetMenu(fileName = "Characters", menuName = "Scriptable Objects/Characters")]
public class CharacterManager : ScriptableObject
{
    public CharacterSheet m_characterSheetPrefab;
    public GoogleSheetData m_raceData;
    public GoogleDocData m_classData;

    public List<Character> m_characterList;

    public Character RollNewCharacter(Transform _uiBackground)
    {
        Character newCharacter = new Character(m_characterSheetPrefab, _uiBackground);

        for (int i = 0; i < newCharacter.m_stats.Length; i++)
        {
            newCharacter.m_stats[i] = RollAbilityScore();
        }

        newCharacter.m_race = Race.RollRandomRace(m_raceData);

        newCharacter.m_classes = Class.RollRandomClasses(m_classData, newCharacter);

        newCharacter.ShowCharacter();

        return newCharacter;
    }

    private int RollAbilityScore()
    {
        int rolledTotal = 0;
        int lowestRoll = int.MaxValue;
        int numberOfDiceToRoll = 4;
        int dieToRoll = 6;

        for (int i = 0; i < numberOfDiceToRoll; i++)
        {
            // Add plus 1 so that our lowest value is 1 and our highest value is the die value rolled
            int rolledValue = UnityEngine.Random.Range(1, dieToRoll + 1);

            rolledTotal += rolledValue;

            if (rolledValue < lowestRoll)
            {
                lowestRoll = rolledValue;
            }
        }

        rolledTotal -= lowestRoll;

        return rolledTotal;
    }
}