using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTargetsScript : GameScript
{
    [SerializeField]
    private Transform myTransform;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float step = 0.01f;


    public override void Use() {
          StartCoroutine(ScaleToZero());


    }
    public void Start()
    {
        myTransform = transform;
    }

    private IEnumerator ScaleToZero()
     { 
        for (int i = this.myTransform.childCount; i > 0; --i) { 
            while (myTransform.GetChild(0).transform.localScale.x > 0.0f)
         {
                step = Time.deltaTime * speed;
                myTransform.GetChild(0).transform.localScale -= new Vector3(step, step, step);
             
             yield return null;
         }
            DestroyImmediate(this.myTransform.GetChild(0).gameObject);
        }
    }

}
