using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopScript : MonoBehaviour
{
    #region Fields

    public int Life = 100;
    public GameObject Highlight;

    private IAstarAI ai;
    private Animator[] animatorList;
    #endregion

    #region MonoBehaviour

    private void Start()
    {
        ai = GetComponent<IAstarAI>();
        animatorList = GetComponentsInChildren<Animator>();
    }

    private void Update()
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
        ai.destination = pos;
        
        foreach (Animator a in animatorList)
        {
            a.SetBool("isWalking", true);
        }
    }
    #endregion
}
