using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will spawn everything
public class Spawner{

	//Singleton code
	static Spawner m_instance;
	public static Spawner Instance
	{
		get 
		{
			if (m_instance == null )
			{
				m_instance = new Spawner();
			}

			return m_instance;
		}
	}

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
		ShipController controller = Helpers.GetShipController(shipContainer);// .GetComponent<PlayerController>();
		controller.m_shipData = InventoryManager.Instance.m_allShips[iShipIndex];
		controller.m_shipModel = shipPrefab;

		//Setup the health component
		HealthComponent healthComponent = shipContainer.AddComponent<HealthComponent>();
		healthComponent.m_fTotalHullHealth = controller.m_shipData.m_fHullStrength;
		healthComponent.m_fTotalShieldHealth = controller.m_shipData.m_fShieldStrength;
		return shipContainer;
	}

	public void SpawnWeapons(GameObject shipObject, List<WeaponData> weapons)
	{
		//Make separate gameobjects inside the ship gameobject and a weaponcontroller to each, it handles everything for the weapon

		//I don't like this, make this mroe generic later
		GameObject weaponsParent =  shipObject.transform.GetChild(2).gameObject;

		for(int i = 0; i < weapons.Count; i++)
		{
			GameObject weapon = new GameObject();
			weapon.transform.SetParent(weaponsParent.transform);
			//Set it up
			weapon.name = weapons[i].m_eName.ToString();
			WeaponComponent weaponComponent = weapon.AddComponent<WeaponComponent>();
			weaponComponent.m_weaponData = weapons[i];
			weapon.transform.localPosition = Vector3.zero;

			//Assign weapon references in the controller,
			Helpers.GetShipController(shipObject).m_equippedWeapons.Add(weaponComponent);
		}
	}

	public GameObject SpawnObject(GameObject obj, Vector3 vPosition, Vector3 vRotation)
	{
		return GameObject.Instantiate(obj, vPosition, Quaternion.LookRotation(Vector3.up, Vector3.forward));
	}
}
