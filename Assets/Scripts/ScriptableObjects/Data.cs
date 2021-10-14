using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Data
{
    public static List<GameObject> SelectedUnits = new List<GameObject>();

    public static void DeselectAll()
    {
        foreach (GameObject g in SelectedUnits.ToArray())
        {
            g.GetComponent<TroopScript>().deselectUnit();
        }
        SelectedUnits = new List<GameObject>();
    }

}
