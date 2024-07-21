using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform VectorBack;
    public Transform VectorForward;
    public Transform VectorLeft;
    public Transform VectorRýght;

    public void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.z = Mathf.Clamp(viewpos.z, VectorBack.transform.position.z, VectorForward.transform.position.z);
        viewpos.x = Mathf.Clamp(viewpos.x, VectorLeft.transform.position.x,VectorRýght.transform.position.x);
        transform.position = viewpos;
    }


}
