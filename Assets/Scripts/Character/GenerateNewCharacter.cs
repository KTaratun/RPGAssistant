using RelevantLobster.Signals;
using UnityEngine;

public class GenerateNewCharacter : MonoBehaviour
{
    [SerializeField] private CharacterManager charManager;
    public Signal[] m_allDataLoadedOn;

    private void Awake()
    {
        Signal.Register(m_allDataLoadedOn, AllDataLoad);
    }

    private void AllDataLoad()
    {
        charManager.RollNewCharacter();
    }
}