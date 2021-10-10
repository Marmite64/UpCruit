using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TroopScript>() != null)
        {
            collision.gameObject.GetComponent<TroopScript>().Highlit.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TroopScript>() != null)
        {
            collision.gameObject.GetComponent<TroopScript>().Highlit.SetActive(false);
        }
    }
}
