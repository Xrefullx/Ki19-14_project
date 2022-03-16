using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : GameScript
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float speed = 1.2f;
    [SerializeField]
    private Vector3 angle;

    public void Start()
    {
        myTransform = transform;
    }
    public override void Use()
    {
        Debug.Log("test2");
        StartCoroutine(Rotate());
    }
    private IEnumerator Rotate()
    {
        Vector3 start = myTransform.eulerAngles;
        float t = 0;
        while (t < 9)
        {
            t += Time.deltaTime * speed;
            myTransform.localRotation = Quaternion.Euler(Vector3.Lerp(start, angle, t));
            yield return null;
        }
    }
}
