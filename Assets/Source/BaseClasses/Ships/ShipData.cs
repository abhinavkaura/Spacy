
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData {
    //Stats

    public enum eTraits
    {
        PHASE_SHIFT = 0,
        OBLITERATE = 1,
        NUM_STATES
    }
    
    public enum eShipNames
    {
        MEGAN = 0,
        JUNKRAT = 1,
        NUM_STATES
    }
    //Name and Prefab
    public eShipNames m_shipName;
    public GameObject m_shipPrefab;

    //Defensive Stats
    public float m_fHullStrength;
    public float m_fShieldStrength;

    //Mobility Stats
    public float m_fHandling;

    //Offensive Stats
    public float m_fEnergy; //Idk if we are using this yet

    public eTraits m_ePrimaryTrait;

    public eTraits m_eSecondaryTrait;

    //Can have unlimited weapons!!!!! jk this list will hold all the weapons that this one model can have, by name
    //This will be populated by nipun's systems for now giving this ship a basic weapon in the inventory manager
    //public List<WeaponData> m_weapons;


    public ShipData(eShipNames sShipName, float fHullStrength, float fShieldStrength, float fHandling, float fEnergy, eTraits ePrimary, eTraits eSecondary)
    {
        m_shipName = sShipName;
        m_fHullStrength = fHullStrength;
        m_fShieldStrength = fShieldStrength;
        m_fHandling = fHandling;
        m_fEnergy= fEnergy;
        m_ePrimaryTrait = ePrimary;
        m_eSecondaryTrait = eSecondary;
    }

}
