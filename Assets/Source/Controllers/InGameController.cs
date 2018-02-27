using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameController : MonoBehaviour {
    /////////////////////////////////////////////////////////////////////////////////////////////
	// Every scene will have its controller to manage things specific to that scene,
    //And we have the persistent GameController to manage/tie in everything else, cuz it persists
    //between scenes.
    /////////////////////////////////////////////////////////////////////////////////////////////

    Vector3 m_vPlayerStartPosition = new Vector3(0.0f,0.0f,-6.0f);
    Spawner m_spawner;
    GameObject m_playerShip;

    void Start () 
    {
        Init();
	}
	


	// Update is called once per frame
	void Update () 
    {
		
	}

    void Init()
    {
        m_spawner = new Spawner();
        //Don't need to add a player controller, as the spawner does that
        SpawnPlayerShip();
        //AssignPlayerController();
    }

    void SpawnPlayerShip()
    {
        //Spawn current ship
        m_playerShip = m_spawner.SpawnShip(InventoryManager.Instance.GetCurrentShipIndex(), m_vPlayerStartPosition, Vector3.zero, true);
    }

    void AssignPlayerController()
    {
        m_playerShip.AddComponent<PlayerController>();
    }
}
