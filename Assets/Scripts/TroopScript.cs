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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody == SelectionBox.GetComponent<Rigidbody2D>())
        {
            Debug.Log("Collision");
            Highlit.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Highlit.SetActive(false);
    }
}
