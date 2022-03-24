using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{ 
    // Start is called before the first frame update
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    float damage = 0.2f;
    InteractiveBox first_box;
    bool isDebug = true;
    // Update is called once per frame
    void Update() { 

            RaycastHit hit;
            if(Input.GetMouseButtonDown(0) && Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit)) {
                var transform_hit = hit.transform;
                if (isDebug)
                    Debug.Log ("select " + hit.collider.name);
                   // Debug.Log ("transform_hit " + transform_hit.position);
                ObstacleItem tt = transform_hit.GetComponent<ObstacleItem>();
                if (tt != null)
                {
                    Debug.Log ("ObstacleItem");
                    tt.GetDamage(damage);
                }
                else if (transform_hit.CompareTag("InteractivePlane"))
                { 
                    SpawnBox(hit.point);
                    Debug.Log ("SpawnBox");
                } 
                else{ 
                    InteractiveBox box = transform_hit.GetComponent<InteractiveBox>();
                    if (box != null)
                    {
                    Debug.Log ("Box update");
                        if(first_box != null)
                            first_box.AddNext(box);
                        else
                            first_box = box;
                    }
                }      
            } 
            else  if(Input.GetMouseButtonDown(1) && Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit)) { 
                var transform_hit = hit.transform;
                InteractiveBox box = transform_hit.GetComponent<InteractiveBox>();
                if (box != null)
                {
                    Debug.Log ("Destroy");
                    Destroy(hit.collider.gameObject);
                }
            }
                 
        }
        void SpawnBox(Vector3 position)
        {
           
            Transform transform_box = Instantiate(prefab.transform,new Vector3(position.x,position.y,position.z)+transform.up,Quaternion.identity); 
            
        }
 
}
