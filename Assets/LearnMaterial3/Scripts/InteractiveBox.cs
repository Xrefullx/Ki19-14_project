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

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log ("select " + hit.collider.name);
            ObstacleItem tt = hit.transform.GetComponent<ObstacleItem>(); ;
            if (tt != null)
            {
                tt.GetDamage(Time.deltaTime);
            }
        }
    }
    void Update()
    { 
        if(next)
            Debug.DrawLine(transform.position, next.Transform.position, Color.red);
    }
    

    
    
}
