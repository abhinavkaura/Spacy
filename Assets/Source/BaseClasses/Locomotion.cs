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

    //Moveto functions are single frame functions
    public void MoveTo(Vector3 vDirection, float fSpeed)
    {
        gameObject.transform.position = gameObject.transform.position + (vDirection.normalized * fSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 vVelocity)
    {
        gameObject.transform.position = gameObject.transform.position + (vVelocity * Time.deltaTime);
    }

    //Move Functions are multi frame functions,,, idk if they should be called move,
    //consult with nipun on a naming convention for move and moveto

    public void Move(Vector3 vDirection, float fSpeed)
    {
        StartCoroutine(Mover(vDirection * fSpeed));
    }

    private IEnumerator Mover(Vector3 vVelocity)
    {
        while (true)
        {
            gameObject.transform.position = gameObject.transform.position + (vVelocity * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
