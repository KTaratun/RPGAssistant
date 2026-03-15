using RelevantLobster.Signals;
using UnityEngine;

public class GenerateNewCharacter : MonoBehaviour
{
    [SerializeField] private CharacterManager m_charManager;
    [SerializeField] private CharacterSheet m_charSheet;
    public Signal[] m_allDataLoadedOn;

    private void Awake()
    {
        Signal.Register(m_allDataLoadedOn, AllDataLoad);
    }

    private void AllDataLoad()
    {
        m_charManager.ClearCharacterData();

        m_charManager.RollNewCharacter(m_charSheet);
    }
}