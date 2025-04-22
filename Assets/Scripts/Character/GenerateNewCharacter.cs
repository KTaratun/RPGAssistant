using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GenerateNewCharacter : MonoBehaviour
{
    [SerializeField] private CharacterManager charManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charManager.RollNewCharacter(transform);
    }
}
