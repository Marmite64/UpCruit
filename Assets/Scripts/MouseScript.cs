using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public GameObject SelectionBox;
    public GameObject FormationArrow;
    public GameObject Troop;
    public float FormationDistance = 1;
    public float Columns;
    void Update()
    {
        //MouseInput
        if (true) 
        {
            // LeftClick
            if (Input.GetMouseButtonDown(0))
            {
                SelectionBox.SetActive(true);
                for (int i = 0; i < Data.SelectedUnits.Count; i++)
                {
                    Data.SelectedUnits[i].GetComponent<TroopScript>().Highlit.SetActive(false);
                }
                Data.SelectedUnits = new List<GameObject>();
                SelectionBox.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                SelectionBox.transform.position = new Vector3(SelectionBox.transform.position.x, SelectionBox.transform.position.y, 0);
            }
            if (Input.GetMouseButton(0))
            {
                SelectionBox.transform.localScale = Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectionBox.transform.position;
            }
            else SelectionBox.SetActive(false);


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
                    Data.SelectedUnits[i].GetComponent<AIDestinationSetter>().target = Instantiate(FormationArrow.transform);
                    Data.SelectedUnits[i].GetComponent<AIDestinationSetter>().target.position = Target;
                }
            }
        }



        //TESTING
        if (Input.GetKeyDown("p"))
        {
            /*transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
            GameObject newTroop = Instantiate(Troop, transform);
            newTroop.GetComponent<TroopScript>().SelectionBox = SelectionBox;*/

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 2.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(Troop, objectPos, Quaternion.identity);
        }
    }
}
