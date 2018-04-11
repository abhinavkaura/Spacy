using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Will hold every kind of movement so that everything that wants to mod its transform comes here and requests stuff from here
public class Locomotion : MonoBehaviour {

	//Adding some methods that move the object this is attached too.

	//Move towards transform specified
	public void Snap(Vector3 vTargetPos)
	{
		gameObject.transform.position = vTargetPos;
	}

	//Moveto functions are single frame functions

	/// <summary>
	/// Moves the attached gameobject in the given direction with a certain speed
	/// </summary>
	/// <param name="vDirection"></param>
	/// <param name="fSpeed"></param>
	public void MoveTo(Vector3 vDirection, float fSpeed)
	{
		gameObject.transform.position = gameObject.transform.position + (vDirection.normalized * fSpeed * Time.deltaTime);
	}
	/// <summary>
	/// Moves the attached gameobject with a given velocity.
	/// </summary>
	/// <param name="vVelocity"></param>
	public void MoveTo(Vector3 vVelocity)
	{
		gameObject.transform.position = gameObject.transform.position + (vVelocity * Time.deltaTime);
	}

	/// <summary>
	/// Moves the attached gameobject with a specified delay
	/// </summary>
	/// <param name="vVelocity"></param>
	/// <param name="fDelay"></param>
	public void MoveToWithDelay(Vector3 vPosition, float fDelay)
	{
		//If delay is 0, movement should be perfect. We can handle this with a lerp
		//Can use a lerp to move here
		transform.position = Vector3.Lerp(transform.position, vPosition, fDelay);
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
