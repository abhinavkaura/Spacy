using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;
using UnityEngine;

public class Parser{

    public Parser()
    {
        
    }

    public List<ShipData> ParseShipData(string a_path)
    {
//        TextAsset asset = (TextAsset)Resources.Load(a_path);
        string text = System.IO.File.ReadAllText(a_path);
        text = text.Trim();
        List<ShipData> ships = new List<ShipData>();
        char[] LineSplitSeparators = {'\n'};
        string[] lines = text.Split(LineSplitSeparators) ;

        foreach(string line in lines)
        {
           
            if(line.StartsWith("#"))
            {
                continue;
            }

            string[] fields = line.Split(',');
            ShipData.eShipNames name = (ShipData.eShipNames)System.Enum.Parse(typeof(ShipData.eShipNames), fields[0]);
            float hull = float.Parse(fields[1]);
            float shield = float.Parse(fields[2]);
            float handling = float.Parse(fields[3]);
            float energy = float.Parse(fields[4]);
            ShipData.eTraits ePrimary = (ShipData.eTraits)System.Enum.Parse(typeof(ShipData.eTraits), fields[5]);
            ShipData.eTraits eSecondary = (ShipData.eTraits)System.Enum.Parse(typeof(ShipData.eTraits), fields[6]);

            ships.Add (new ShipData (name,hull,shield,handling,energy,ePrimary,eSecondary));
        }

        return ships;
    }

    public List<WeaponData> ParseWeaponData(string a_path)
    {
        string text = System.IO.File.ReadAllText(a_path);
        text = text.Trim();
        List<WeaponData> weapons = new List<WeaponData>();
        char[] LineSplitSeparators = {'\n'};
        string[] lines = text.Split(LineSplitSeparators) ;

        foreach(string line in lines)
        {

            if(line.StartsWith("#"))
            {
                continue;
            }

            string[] fields = line.Split(',');
            WeaponData.eWeaponNames name = (WeaponData.eWeaponNames)System.Enum.Parse(typeof(WeaponData.eWeaponNames), fields[0]);
            float rateOfFire = float.Parse(fields[1]);
            float impactDamage = float.Parse(fields[2]);
            WeaponData.eWeaponType type = (WeaponData.eWeaponType)System.Enum.Parse(typeof(WeaponData.eWeaponType), fields[3]);
            bool isAOE = bool.Parse(fields[4]);
            float blastRadius = float.Parse(fields[5]);
            float AOEDamage = float.Parse(fields[6]);
            float falloff = float.Parse(fields[7]);
            float projectileSpeed = float.Parse(fields[8]);

            weapons.Add (new WeaponData (name,rateOfFire,impactDamage,type,isAOE,blastRadius,AOEDamage,falloff,projectileSpeed));
        }

        return weapons;
    }
}
