using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopScript : MonoBehaviour
{
    #region Fields

    [Header("Stats")]
    public int Life = 100;
    public Faction unitFaction;

    [Header("References")]
    public GameObject Highlight;
    public SpriteRenderer[] factionSprites;

    [Header("Misc")]
    public bool isSelected = false;
    public bool isPlayerControlled = false;

    private IAstarAI ai;
    private Animator[] animatorList;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        ai = GetComponent<IAstarAI>();
        animatorList = GetComponentsInChildren<Animator>();
        foreach (SpriteRenderer s in factionSprites) s.color = unitFaction.factionColor;
        isPlayerControlled = unitFaction.playerControlled;
    }

    void Update()
    {
        if (ai.reachedDestination)
        {
            foreach (Animator a in animatorList)
            {
                a.SetBool("isWalking", false);
            }
        }
    }
    #endregion

    #region Methods
    public void setDestination(Vector3 pos)
    {
        // Move
        ai.destination = pos;

        // Animation
        foreach (Animator a in animatorList)
        {
            a.SetBool("isWalking", true);
        }
    }

    public void selectUnit()
    {
        Highlight.SetActive(true);
        Data.SelectedUnits.Add(gameObject);
    }

    public void deselectUnit()
    {
        Highlight.SetActive(false);
        Data.SelectedUnits.Remove(gameObject);
        isSelected = false;
    }
    #endregion
}
