using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipData {
    //Stats

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
public class Ship : MonoBehaviour
{
    //Do I even need this class??????
    //Not using it for now
    //Gonna make ship stats var in the player/AI controller, which is better

//    public ShipStats.eShipNames m_shipName;
//    public ShipStats m_Stats;
//    public GameObject m_shipPrefab;
//
//
//
//    public Ship(ShipStats.eShipNames sShipName, float fHullStrength, float fShieldStrength, float fHandling, float fEnergy, ShipStats.eTraits ePrimary, ShipStats.eTraits eSecondary)
//    {
//        m_Stats = new ShipStats();
//        m_shipName = sShipName;
//        m_Stats.m_fHullStrength = fHullStrength;
//        m_Stats.m_fShieldStrength = fShieldStrength;
//        m_Stats.m_fHandling = fHandling;
//        m_Stats.m_fEnergy= fEnergy;
//        m_Stats.m_ePrimaryTrait = ePrimary;
//        m_Stats.m_eSecondaryTrait = eSecondary;
//    }
}
