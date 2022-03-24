using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue;
    public UnityEvent onDestroyObstacle;
    public MeshRenderer mesh;
    public Color fullHPColor;
    public Color zeroHPColor;


    public void Start()
    {
        currentValue = 1;
    }

    public void GetDamage(float value)
    {
        currentValue -= value; 
        mesh.materials[0].color = Color.Lerp(zeroHPColor, fullHPColor, currentValue);
        if (currentValue <= 0)
        {
            currentValue = 0;
          
            mesh.materials[0].color = zeroHPColor;
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }
    }


    /*private IEnumerator ChangeColor()
    {
        Vector3 start = myTransform.eulerAngles;
        float t = 0;
        Vector3 angle = new Vector3(0, 90, 0);
        while (t < 9)
        {
            t += Time.deltaTime * speed;
            myTransform.localRotation = Quaternion.Euler(Vector3.Lerp(start, angle, t));
            yield return null;
        }
    }*/
}
