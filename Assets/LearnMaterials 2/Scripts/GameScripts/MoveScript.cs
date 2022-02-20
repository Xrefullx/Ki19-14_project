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
        
        while (myTransform.position != endPosition)
        { 
            myTransform.position = Vector3.Lerp(transform.position,endPosition, speed * Time.deltaTime);
            Debug.Log(myTransform.position);
            yield return null;
        }
    }
}
