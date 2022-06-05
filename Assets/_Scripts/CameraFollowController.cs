using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraOffset = new Vector3(0f, 1.3f, -3f);
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Player").transform;

    }

    void LateUpdate()
    {

        // Se setea la posicion de la camara teniendo en cuenta el offset determinado
        this.transform.position = target.TransformPoint(cameraOffset);
        // Se hace que la camara apunte a la misma direccion que el objeto Player
        this.transform.LookAt(target);

    }
}
