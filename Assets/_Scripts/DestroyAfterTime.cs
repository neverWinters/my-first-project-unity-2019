using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField]
    private float destroyDelay = 1.5f;

    // Update is called once per frame
    void Start()
    {

        Destroy(this.gameObject, destroyDelay);

    }
}
