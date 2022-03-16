using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StepScript : GameScript
{
    [SerializeField]
    private float speed = 1.2f;

    [SerializeField]
    private GameObject mygameObject;

    [SerializeField]
    private float step = 1;

    [SerializeField]
    private float count = 1;

    [SerializeField]
    private Vector3 spawn_point;
    [ContextMenu("Uecm")]
    public override void Use() 
    {
        Debug.Log("test3");
        StartCoroutine(Step());
    }

    private IEnumerator Step()
    {
        for (int i = 0; i < count; i++)
        {
            spawn_point.x += step;
            Instantiate(mygameObject, spawn_point, Quaternion.identity,transform);
            yield return null;

        }
        
    }
}
