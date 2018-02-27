using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager{

    ///////////////////////////////////////////////////////////////////////////////////////
    /// This Class will handle the player's inventory, everything from his current ship
    /// to his owned ships to his equipped weapons on each ship.
    ///////////////////////////////////////////////////////////////////////////////////////

    //Singleton code
    static InventoryManager m_instance;
    public static InventoryManager Instance
    {
        get 
        {
            if (m_instance == null )
            {
                m_instance = new InventoryManager();        
            }

            return m_instance;
        }
    }
    
    public List<ShipData> m_allShips;
    public List<WeaponData> m_allWeapons;
    Parser m_parser;

    int m_iCurrentShip;

    //Thinking of replacing the list above with a dictionary instead, cuz then we can just do everything with the shipNames enum instead of using an index and list traversal
    Dictionary<ShipData.eShipNames,ShipData> m_dAllShips;

    public void Init()
    {
        m_parser = new Parser();
        SetupShips();
        SetupWeapons();

        //Setting the default ship to 0 for now, will replace this with nipun's UI which will store and get the current ship
        SetCurrentShipIndex(0);
    }

    void SetupShips()
    {
        //Parse all ships from data files
        m_allShips = m_parser.ParseShipData(Paths.SHIP_DATA);

        //Add models to all these ships
        for(int i=0; i<m_allShips.Count;i++)
        {
            //TODO this method is not as optimised, as I'll have to make a copy of the prefab for later use, thinking of copying these values into the existing prefabs instead of into a ship class?

            //So, These will be the stored ships. As a master, I didn't really wanna make a copy, but that seems like the best way right now. Every spawned ship will use the ship class prefab stored in the ship class
            //and add the ship class back as a component, also ship is MONO so I still have some quirks to figure out. But it works ?
            GameObject shipPrefab = (GameObject)Resources.Load(Paths.SHIP_MODELS + m_allShips[i].m_shipName.ToString().ToUpper());
//            shipPrefab.AddComponent<Ship>();

            Debug.Log(Paths.SHIP_PREFABS + m_allShips[i].m_shipName.ToString().ToUpper() + ".prefab");
            m_allShips[i].m_shipPrefab = shipPrefab;
        }
        
    }

    void SetupWeapons()
    {
        
    }

    public void SetCurrentShipIndex(int iShipIndex)
    {
        m_iCurrentShip = iShipIndex;
    }

    public int GetCurrentShipIndex()
    {
        return m_iCurrentShip;
    }


}
