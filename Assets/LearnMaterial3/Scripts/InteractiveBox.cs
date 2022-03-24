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
       
    }
    void Update()
    { 
        if(next)
        { 
            Debug.DrawLine(transform.position, next.Transform.position, Color.red);
            Ray ray = new Ray(Transform.position, next.Transform.position);

            RaycastHit hit;
            if (Physics.Linecast(transform.position,next.transform.position, out hit))
            {
                
                ObstacleItem tt = hit.transform.GetComponent<ObstacleItem>(); 
                if (tt != null)
                {
                    Debug.Log("select " + hit.collider.name);
                    tt.GetDamage(Time.deltaTime);
                }
            }
        }

    }
    

    
    
}
