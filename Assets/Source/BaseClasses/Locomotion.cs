using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Will hold every kind of movement so that everything that wants to mod its transform comes here and requests stuff from here
public class Locomotion : MonoBehaviour {

    //Adding some methods that mode the object this is attached too.

    //Move towards transform specified
    public void Snap(Vector3 vTargetPos)
    {
        gameObject.transform.position = vTargetPos;
    }

    void Update()
    {
        
    }

    public void Move(Vector3 vDirection, float fSpeed)
    {
        gameObject.transform.position = gameObject.transform.position + (vDirection.normalized * fSpeed);
    }

    private void StartMoveRequest()
    {
        
    }
}
