using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers {

    public static ShipController GetShipController(GameObject obj)
    {
        return obj.GetComponent<ShipController>();
    }
}
