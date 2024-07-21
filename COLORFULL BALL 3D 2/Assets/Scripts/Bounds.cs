using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform VectorBack;
    public Transform VectorForward;
    public Transform VectorLeft;
    public Transform VectorRęght;

    public void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.z = Mathf.Clamp(viewpos.z, VectorBack.transform.position.z, VectorForward.transform.position.z);
        viewpos.x = Mathf.Clamp(viewpos.x, VectorLeft.transform.position.x,VectorRęght.transform.position.x);
        transform.position = viewpos;
    }


}
