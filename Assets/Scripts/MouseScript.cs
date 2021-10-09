using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public GameObject SelectionBox;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectionBox.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectionBox.transform.position = new Vector3(SelectionBox.transform.position.x, SelectionBox.transform.position.y, 0);
        }
        if (Input.GetMouseButton(0))
        {
            SelectionBox.SetActive(true);
            SelectionBox.transform.localScale = Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectionBox.transform.position;
        }
        else SelectionBox.SetActive(false);

    }
}
