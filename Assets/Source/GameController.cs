using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
    public enum eGameState
    {
        INVALID = -1,
        LOADING_SCREEN = 0,
        MAIN_MENU,
        INGAME,
        FINISHING_SCREEN,
        NUM_STATES
    }

    public static GameController Instance;
    eGameState g_eCurrentGameState = eGameState.MAIN_MENU;

    void Start()
    {
        //Adding persistence
        Object.DontDestroyOnLoad(gameObject);
        Instance = this;
        Init();

    }

    public void LoadScene(int iSceneIndex)
    {
        SceneManager.LoadSceneAsync(iSceneIndex);
    }

    public void Init()
    {
        Assert.IsTrue(g_eCurrentGameState > eGameState.INVALID, "Game State should never be invalid");

        //Load ships and weapons
        InventoryManager.Instance.Init();
    }
}
