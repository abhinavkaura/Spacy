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
}
