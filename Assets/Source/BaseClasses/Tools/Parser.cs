using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows;
using UnityEngine;

public class Parser{

    public Parser()
    {
        
    }

    public List<Ship> ParseShipData(string a_path)
    {
//        TextAsset asset = (TextAsset)Resources.Load(a_path);
        string text = System.IO.File.ReadAllText(a_path);
        text = text.Trim();
        List<Ship> ships = new List<Ship>();
        char[] LineSplitSeparators = {'\n'};
        string[] lines = text.Split(LineSplitSeparators) ;

        int column = 0;
        foreach(string line in lines)
        {
           
            if(line.StartsWith("NAME"))
            {
                continue;
            }

            string[] fields = line.Split(',');

            string name = fields[0];
            float hull = float.Parse(fields[1]);
            float shield = float.Parse(fields[2]);
            float handling = float.Parse(fields[3]);
            float energy = float.Parse(fields[4]);
            ShipStats.eTraits ePrimary = (ShipStats.eTraits)System.Enum.Parse(typeof(ShipStats.eTraits), fields[5]);
            ShipStats.eTraits eSecondary = (ShipStats.eTraits)System.Enum.Parse(typeof(ShipStats.eTraits), fields[6]);

            ships.Add (new Ship (name,hull,shield,handling,energy,ePrimary,eSecondary));
        }
        return ships;
    }
}
