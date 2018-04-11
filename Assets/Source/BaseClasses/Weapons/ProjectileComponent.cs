using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
	public float m_fDamage;
	public float m_fVelocity;

	//Do I wanna pool these or destroy them???????? 
	//TODO: Make a pooler DestructionManager.cs
	public float m_fLifeTime;

	public int m_OwnerHash;

	public void InitProjectile(float fDamage, float fVelocity)
	{
		m_fDamage = fDamage;
		m_fVelocity = fVelocity;
		AddVelocity();
	}

	public void DestroyProjectile()
	{
		//Do other things here like start particle effects
		//GameObject.Destroy(this.gameObject);
	}

	void AddVelocity()
	{
		GetComponent<Locomotion>().Move(Vector3.forward, m_fVelocity);
	}

	void OnTriggerEnter()
	{
		DestroyProjectile();
	}

}
