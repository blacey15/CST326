using UnityEngine;

public class LookAt : MonoBehaviour {
    // todo - make an object look at another object

    public Transform ball;

    void Update()
    {
        transform.LookAt(ball, Vector3.up);
    }
}
