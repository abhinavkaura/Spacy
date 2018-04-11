using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
	//This will be attached to every object that is gonna have some health, all the weapon damage 
	//hull health, shield health and other calculations will be done here, we can attach this to anything like
	// a ship, to a drone, to even an asteroid or a comet

	public float m_fCurrentHullHealth;
	public float m_fTotalHullHealth;

	public float m_fCurrentShieldHealth;
	public float m_fTotalShieldHealth;

	private void Start()
	{
		//Do we wanna include persistent health here? Make the user repair his ship?? Can be done here. if we want i.e.
		m_fCurrentHullHealth = m_fTotalHullHealth;
		m_fCurrentShieldHealth = m_fTotalShieldHealth;
	}

	//Methods that calculate damage taken
	public void OnHitProjectile(float fDamage)
	{
		//Function for adding UI/Particles/more stufff
		Debug.Log("PROJECTILE HIT ON" + this.transform.name);

		//This will get multiple calls by the weapon component i.e. 1st on impact and second on aoe
		ProcessDamageTaken(fDamage);
	}

	void ProcessDamageTaken(float fDamage)
	{
		float fDamageBuffer = fDamage;
		if (m_fCurrentShieldHealth > 0.0f)
		{
			fDamageBuffer = ComputeShieldHealth(fDamage);
		}

		if (fDamageBuffer > 0.0f && m_fCurrentHullHealth > 0.0f)
		{
			ComputeHullHealth(fDamageBuffer);
		}
	}

	float ComputeShieldHealth(float fDamage)
	{
		//If the damage coming in is more than max health just send over the remainder and apply it on the hull
		float fReturnValue = m_fCurrentShieldHealth - fDamage;

		if (fReturnValue < 0.0f)
		{
			m_fCurrentShieldHealth = 0.0f;
			return Mathf.Abs(fReturnValue);
		}
		else
		{
			m_fCurrentShieldHealth = fReturnValue;
			return 0.0f;
		}
	}

	float ComputeHullHealth(float fDamage)
	{
		//Do we need a return value here? IDK gonna send one anyway
		float fReturnValue = m_fCurrentHullHealth - fDamage;

		if (fReturnValue < 0.0f)
		{
			m_fCurrentHullHealth = 0.0f;
			return Mathf.Abs(fReturnValue);
		}
		else
		{
			m_fCurrentHullHealth = fReturnValue;
			return 0.0f;
		}
	}

	/// <summary>
	/// I don't think we need Colliders at the moment so subscribing to trigger events only
	/// </summary>
	void OnTriggerEnter(Collider otherTrigger)
	{
		//Handle Projectiles
		//Process the projectile here, do we want our own bullets to damage us???Probably should add
		//a bool later to handle that in weaponData, would probably be best to calculate damage to self
		//during aoe
		ProjectileComponent projectile = otherTrigger.GetComponent<ProjectileComponent>();

		if (projectile.m_OwnerHash != gameObject.GetHashCode())
		{
			float fDamage = projectile.m_fDamage;
			OnHitProjectile(fDamage);
		}
	}

	void OnTriggerStay(Collider otherTrigger)
	{

	}

	void OnTriggerExit(Collider otherTrigger)
	{

	}

}
