using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TroopScript>() != null)
        {
            collision.gameObject.GetComponent<TroopScript>().Highlit.SetActive(true);
            Data.SelectedUnits.Add(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<TroopScript>() != null && Input.GetMouseButton(0))
        {
            collision.gameObject.GetComponent<TroopScript>().Highlit.SetActive(false);
            Data.SelectedUnits.Remove(collision.gameObject);
        }
    }

}
