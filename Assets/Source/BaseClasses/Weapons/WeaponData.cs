using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData{

    public enum eWeaponType
    {
        INVALID = -1,
        PROJECTILE_BULLET = 0,
        RAY_CAST_BULLET = 1,
        LASER = 2,
        MISSILE = 3,
        NUM_STATES
    }

    public enum eWeaponNames
    {
        BOLTER = 0,
        DUBSTEP_KILLER = 1,
        SHARK_ATTACK = 2,
        NUM_STATES
    }

    public eWeaponNames m_eName;
    public GameObject m_weaponPrefab;
    public GameObject m_ammoPrefab;
    public float m_fRateOfFire;
    public float m_fImpactDamage;
    public eWeaponType m_eType;
    public float m_fProjectileSpeed;

    public bool m_bIsAOE;
    public float m_fBlastRadius;
    public float m_fAOEDamage;
    //Implement through curve fitting??
    public float m_fFalloff;

    public WeaponData(eWeaponNames a_eName, float a_fRateOfFire, float a_fImpactDamage, eWeaponType a_eType,
        bool a_bIsAOE, float a_fBlastRadius, float a_fAOEDamage, float a_fFalloff, float a_fProjectileSpeed)
    {
        m_eName = a_eName;
        m_fRateOfFire = a_fRateOfFire;
        m_fImpactDamage = a_fImpactDamage;
        m_eType = a_eType;
        m_bIsAOE = a_bIsAOE;
        m_fBlastRadius = a_fBlastRadius;
        m_fAOEDamage = a_fAOEDamage;
        m_fFalloff = a_fFalloff;
        m_fProjectileSpeed = a_fProjectileSpeed;
    }
}
