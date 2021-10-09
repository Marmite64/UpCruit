using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopScript : MonoBehaviour
{
    public int Life = 100;
    public GameObject Highlit;
    public GameObject SelectionBox;

    private void Start()
    {
        Highlit.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == SelectionBox)
        {
            Highlit.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Highlit.SetActive(false);
    }
}
