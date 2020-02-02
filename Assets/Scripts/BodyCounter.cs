using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCounter : MonoBehaviour
{
    public static Dictionary<string, Dictionary<string, int>> Memorial = new Dictionary<string, Dictionary<string, int>>();

    public static void RecordDeath(string creature, string deathType, int amount)
    {
        if (Memorial.ContainsKey(creature))
        {
            if (Memorial[creature].ContainsKey(deathType))
            {
                Memorial[creature][deathType] += amount;
            }
            else
            {
                Memorial[creature] = new Dictionary<string, int>();
                Memorial[creature].Add(deathType, amount);
            }
        }
        else
        {
            Memorial.Add(creature, new Dictionary<string, int>());
            Memorial[creature].Add(deathType, amount);
        }
    }
}
