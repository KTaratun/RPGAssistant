using RelevantLobster;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : RelevantLobsterBehavior
{
    public void SwitchScene(string _sceneToSwitchTo)
    {
        SceneManager.LoadScene(_sceneToSwitchTo);
    }
}
