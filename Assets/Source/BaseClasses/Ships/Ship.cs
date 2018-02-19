using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public string m_shipName;
    public ShipStats m_Stats;
    public GameObject m_gModel;



    public Ship(string sShipName, float fHullStrength, float fShieldStrength, float fHandling, float fEnergy, ShipStats.eTraits ePrimary, ShipStats.eTraits eSecondary)
    {
        m_Stats = new ShipStats();
        m_shipName = sShipName;
        m_Stats.m_fHullStrength = fHullStrength;
        m_Stats.m_fShieldStrength = fShieldStrength;
        m_Stats.m_fHandling = fHandling;
        m_Stats.m_fEnergy= fEnergy;
        m_Stats.m_ePrimaryTrait = ePrimary;
        m_Stats.m_eSecondaryTrait = eSecondary;
    }
}
