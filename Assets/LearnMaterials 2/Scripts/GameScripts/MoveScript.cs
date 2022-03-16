using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : GameScript
{ 
    
    [SerializeField]
    private Transform myTransform;
    [SerializeField] 
    private Vector3 startPosition = Vector3.zero;
    [SerializeField] 
    private Vector3 endPosition;

    [SerializeField] 
    private float speed = 1.2f;

    public void Start()
    { 
        myTransform = transform;
        myTransform.position = startPosition;
    }
    public override void Use()
    {
        Debug.Log("test");
       StartCoroutine(MoveToPoint());
    }
    private IEnumerator MoveToPoint()
    {
        Vector3 start = myTransform.eulerAngles;
        float t = 0;
        Vector3 angle = new Vector3(0,90,0);
        while (t < 9)
        {
            t += Time.deltaTime * speed;
            myTransform.localRotation  = Quaternion.Euler(Vector3.Lerp(start, angle, t));
            yield return null;
        } 
    }
}
