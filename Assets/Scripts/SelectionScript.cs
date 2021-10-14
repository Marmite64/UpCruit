using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Condition: Object has to be of type Unit
        TroopScript t;
        if ((t = collision.gameObject.GetComponent<TroopScript>()) && t.isPlayerControlled) t.selectUnit();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // Condition: Object has to be of type Unit, not selected and RMB must be pressed
        TroopScript t;
        if ((t = collision.gameObject.GetComponent<TroopScript>()) && !t.isSelected && Input.GetMouseButton(0)) t.deselectUnit();
    }

}
