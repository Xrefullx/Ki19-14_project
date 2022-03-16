using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    public InteractiveBox next;
    public Transform Transform;

    public void Start()
    {
        Transform = transform;
    }


    public void AddNext(InteractiveBox box)
    {
        

        if (next == null)
        {
            next = box;
        }
        Ray ray = new Ray(Transform.position, box.Transform.position);
        Debug.DrawLine(transform.position, box.Transform.position, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            ObstacleItem tt = hit.transform.GetComponent<ObstacleItem>(); ;
            if (tt != null)
            {
                tt.GetDamage(Time.deltaTime);
            }
        }
    }

    
    
}
