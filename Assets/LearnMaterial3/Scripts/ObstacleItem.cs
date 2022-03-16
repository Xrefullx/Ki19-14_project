using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue ;
    public UnityEvent onDestroyObstacle;
    public MeshRenderer mesh;

    public void GetDamage(float value)
    { 
        currentValue -= value;
        currentValue = Mathf.Clamp(currentValue,0,1);
        if (currentValue == 1) {
            mesh.materials[0].color = Color.Lerp(mesh.materials[0].color, Color.white, value);
        } else if (currentValue < 0.9 && currentValue > 0)
        {
            mesh.materials[0].color = Color.Lerp(mesh.materials[0].color, Color.red,  value); 
        }
        else if (currentValue == 0){
            onDestroyObstacle.Invoke();
            Debug.Log ("Invoke");
            Destroy(gameObject);
        }
    }
    
}
