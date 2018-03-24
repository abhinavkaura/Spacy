using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour {

    public GameObject optionsPanel;

    public void OnClickStart()
    {
        GameController.Instance.LoadScene((int)GameController.eGameState.INGAME);
    }

    public void OnClickExit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit ();
        #endif
    }

    public void OnClickOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void OnClickOptionsClose()
    {
        optionsPanel.SetActive(false);
    }

}
