using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public ShipData m_shipData;
	public GameObject m_shipModel;
	public List<WeaponComponent> m_equippedWeapons;
	public int m_iCurrentSelectedWeapon = 0;

	public void PressTrigger(int iWeaponIndex)
	{
		m_equippedWeapons[iWeaponIndex].ProcessFiringWeapon();
	}

}
