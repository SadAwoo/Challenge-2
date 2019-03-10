using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidetoside : MonoBehaviour
{
    public float speed;
    public float y;
    public float x1;
    public float x2;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(x1, x2, Mathf.PingPong(Time.time * speed, 1)), y, 0);
    }
}
