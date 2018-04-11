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

	//Master lists
	public List<ShipData> m_allShips;
	public List<WeaponData> m_allWeapons;

	//Owned stuff
	public List<ShipData> m_ownedShips;
	public List<WeaponData> m_ownedWeapons;
	int m_iCurrentShip;


	Parser m_parser;
	//TODO: How do you wanna handle the loadout? iS it per ship or is it per mission?? Should I just make a dictionary
	//With the key as the ship and the value as the weapons attached ?? and give the user to modify it every mission/session??
	//Talk to Nipun about this^
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


	#region Ship Code
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
			//Just had another idea, whyd on't I just store a path here and just spawn it when I need it??? yea Who's thef uckign genius
			GameObject shipPrefab = (GameObject)Resources.Load(Paths.SHIP_MODELS + m_allShips[i].m_shipName.ToString().ToUpper());
//            shipPrefab.AddComponent<Ship>();

			Debug.Log(Paths.SHIP_PREFABS + m_allShips[i].m_shipName.ToString().ToUpper() + ".prefab");
			m_allShips[i].m_shipPrefab = shipPrefab;
		}
		
	}


	public void SetCurrentShipIndex(int iShipIndex)
	{
		m_iCurrentShip = iShipIndex;
	}

	public int GetCurrentShipIndex()
	{
		return m_iCurrentShip;
	}
	#endregion

	#region Weapon Code
	void SetupWeapons()
	{
		m_allWeapons = m_parser.ParseWeaponData(Paths.WEAPON_DATA);

		for(int i=0; i< m_allWeapons.Count;i++)
		{
			
			GameObject ammoPrefab = (GameObject)Resources.Load(Paths.WEAPON_AMMO + m_allWeapons[i].m_eName.ToString().ToUpper() + "_AMMO");
			m_allWeapons[i].m_ammoPrefab = ammoPrefab;
		}
	}

	#endregion

}
