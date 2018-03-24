using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour 
{
    
    //Every weapon will have a controller attached to it.
    //This will calculate everything from when to fire next to how much damage it will cause, all calls from the 
    //Player and AI controller will come here

    public WeaponData m_weaponData;

    //Turn this bool into a separate conditional getter later
    bool bCanFire= true;

    public void ProcessFiringWeapon()
    {
        //Process refire rates here
        if(bCanFire)
        {
            bCanFire = false;
            Invoke("ResetCanFireBoolAccordingToFireRate",1 / m_weaponData.m_fRateOfFire);
            FireWeapon();
        }
        
    }

    void ResetCanFireBoolAccordingToFireRate()
    {
        bCanFire = true;
    }
    
    void FireWeapon()
    {
        //Write Firing logic here
        Debug.Log("Fire");
        SpawnBullet();
    }

    void SpawnBullet()
    {
        GameObject a_bullet = Spawner.Instance.SpawnObject(m_weaponData.m_ammoPrefab, this.transform.position, Vector3.zero);
        a_bullet.GetComponent<Locomotion>().Move(Vector3.forward,m_weaponData.m_fProjectileSpeed);
    }

}
