using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float yawDegreesPerSecond = 45;

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        t.Rotate(eulers:new Vector3(x:0f, y:yawDegreesPerSecond * Time.deltaTime, z:0f));
    }
}
