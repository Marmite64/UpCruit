using UnityEngine;

[CreateAssetMenu(fileName = "MyFaction", menuName = "ScriptableObjects/Faction", order = 1)]
public class Faction : ScriptableObject
{
    public string factionName = "defaultName";
    public Color factionColor = new Color(0, 0, 0, 255);
    public bool playerControlled = false;
}