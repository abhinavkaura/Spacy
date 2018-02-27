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
        NUM_TYPES
    }

    public float m_fRateOfFire;
    public float m_fImpactDamage;
    public eWeaponType m_eType;

    public bool m_bAOE;
    public float m_fBlastRadius;
    public float m_AOEDamage;
    //Implement through curve fitting??
    public float m_fFalloff;
}
