using UnityEngine;
using System.Collections;

public class TroopScript : MonoBehaviour
{
    public Vector3 Target = new Vector3(0,0,0);
    public Vector3 movement;
    public float Distance;
    public float movementSpeed = 1f;
    void Update()
    {
        Distance = Vector3.Distance(Target, transform.position);
        if (Distance > 1f);
        {
            movement = Target - transform.position;
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back, movement);
            }
            transform.position += transform.up * Time.deltaTime * movementSpeed;
        }
    }
}
