using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will spawn everything
public class Spawner{

    public GameObject SpawnShip(int iShipIndex, Vector3 vPosition, Vector3 vRotation, bool bIsPlayer)
    {
        GameObject shipContainer;
        if(bIsPlayer)
        {
            shipContainer = GameObject.Instantiate((GameObject)(Resources.Load(Paths.SHIP_CONTAINER+"PCONTAINER")));
            shipContainer.name = "Player";
        } 
        else
        {
            //Add an AI continer, not sure if it'll be different or not, adding a normal player container for now. 
            shipContainer = GameObject.Instantiate((GameObject)(Resources.Load(Paths.SHIP_CONTAINER+"PCONTAINER")));
            shipContainer = null;
        }

        //Spawn the prefab and set the in game gameobject up
        GameObject shipPrefab = GameObject.Instantiate(InventoryManager.Instance.m_allShips[iShipIndex].m_shipPrefab, shipContainer.transform);
        shipPrefab.name = "ShipPrefab";
        shipPrefab.transform.localPosition = Vector3.zero;
        shipContainer.transform.position = vPosition;
        shipContainer.transform.eulerAngles = vRotation;

        //Add stats to this spawned ship
        PlayerController pController = shipContainer.GetComponent<PlayerController>();
        pController.m_shipData = InventoryManager.Instance.m_allShips[iShipIndex];
        pController.m_shipModel = shipPrefab;
        return shipContainer;
    }
}
