using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float FormationDistance = 1;
    [SerializeField] private float Columns;
    [SerializeField] private LayerMask layerMask;

    [Header("References")]
    [SerializeField] private GameObject SelectionBox;
    [SerializeField] private GameObject FormationArrow;
    
    [Header("Testing")]
    [SerializeField] private GameObject Troop;
    [SerializeField] private Faction playerFaction;
    [SerializeField] private Faction enemyFaction;

    void Update()
    {
        # region MouseInput

        // LeftClick
        if (Input.GetMouseButtonDown(0))
        {
            Data.DeselectAll();

            // Single select
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 10, layerMask);

            TroopScript t;
            if (hit.collider != null && (t = hit.collider.gameObject.GetComponent<TroopScript>()) && t.isPlayerControlled) t.selectUnit();

            // Multi select - Draw selection box
            SelectionBox.SetActive(true);
            SelectionBox.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectionBox.transform.position = new Vector3(SelectionBox.transform.position.x, SelectionBox.transform.position.y, 0);
        }
        if (Input.GetMouseButton(0))
        {
            SelectionBox.transform.localScale = Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectionBox.transform.position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            SelectionBox.SetActive(false);
            foreach (GameObject t in Data.SelectedUnits) 
            {
                t.GetComponent<TroopScript>().isSelected = true;
            }
        }

        // RightClick
        if (Input.GetMouseButtonDown(1))
        {
            FormationArrow.SetActive(true);
            FormationArrow.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
        if (Input.GetMouseButton(1))
        {
            float ArrowLength = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), FormationArrow.transform.position);
            FormationArrow.transform.localScale = new Vector3(ArrowLength,1 , 1);

            Vector2 lookDir = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - FormationArrow.GetComponent<Rigidbody2D>().position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            FormationArrow.GetComponent<Rigidbody2D>().rotation = angle;
        }
        if (Input.GetMouseButtonUp(1))
        {
            FormationArrow.SetActive(false);
            float Length = Mathf.Floor(FormationArrow.transform.localScale.x);

            if (Length < 3)     { Columns = Mathf.Floor(Mathf.Pow(Data.SelectedUnits.Count, 2f / 3f)); }
            else                { Columns = Mathf.Ceil(Length); }
            if (Columns > Data.SelectedUnits.Count) Columns = Data.SelectedUnits.Count;

            for (int i = 0; i < Data.SelectedUnits.Count; i++)
            {
                Vector3 Target = FormationArrow.transform.position + FormationArrow.transform.up * FormationDistance * ((i % Columns) + 0.5f - Columns / 2);
                Target += FormationArrow.transform.right * -Mathf.Floor(i / Columns);
                Data.SelectedUnits[i].GetComponent<TroopScript>().setDestination(Target);
            }
        }

        #endregion


        //TESTING
        if (Input.GetKeyDown("1") || Input.GetKey("1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0f;
            GameObject g = Instantiate(Troop, objectPos, Quaternion.identity);
            g.GetComponent<TroopScript>().unitFaction = playerFaction;
        }
        if (Input.GetKeyDown("2") || Input.GetKey("2"))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0f;
            GameObject g = Instantiate(Troop, objectPos, Quaternion.identity);
            g.GetComponent<TroopScript>().unitFaction = enemyFaction;
        }
    }
}
