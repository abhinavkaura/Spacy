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
    
    List<Ship> m_allShips;
    List<Weapon> m_allWeapons;
    Parser m_parser;


    public void Init()
    {
        m_parser = new Parser();
        m_allShips = m_parser.ParseShipData("Assets/Data/ShipData/ShipData.csv");
        Debug.Log("MARK");
    }

}
