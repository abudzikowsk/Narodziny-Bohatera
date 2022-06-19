using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaukaProgramowania : MonoBehaviour
{
    private Transform camTransform;
    public GameObject directionaLight;
    private Transform lightTransform;

    // Start is called before the first frame update
    void Start()
    {
        directionaLight = GameObject.Find("Directional Light");

        camTransform = this.GetComponent<Transform>();
        Debug.Log(camTransform.localPosition);
    }
}
