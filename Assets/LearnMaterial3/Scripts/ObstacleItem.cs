using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue ;
    public UnityEvent onDestroyObstacle;
    public MeshRenderer mesh;

    void GetDamage(float value)
    {
        currentValue -= value;
        if (currentValue == 1) {
            mesh.materials[0].color = Color.Lerp(mesh.materials[0].color, Color.white, value);
        } else if (currentValue == 0)
        {
            mesh.materials[0].color = Color.Lerp(mesh.materials[0].color, Color.red, value);
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
