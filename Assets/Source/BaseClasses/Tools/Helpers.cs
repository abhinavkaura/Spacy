using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers {

	//Realy slow helper, mod it!
	public static ShipController GetShipController(GameObject obj)
	{
		if (obj.GetComponent<ShipController>())
		{
			return obj.GetComponent<ShipController>();
		}
		else if(obj.GetComponentInParent<ShipController>())
		{
			return obj.GetComponentInParent<ShipController>();
		}
		else if(obj.GetComponentInChildren<ShipController>())
		{
			return obj.GetComponentInChildren<ShipController>();
		}

		return null;
	}
}
