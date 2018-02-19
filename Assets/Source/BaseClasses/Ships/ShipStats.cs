using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats {
    //Stats

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

}
