using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpandDown : MonoBehaviour
{
    public float speed;
    public float x;
    public float y1;
    public float y2;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x, Mathf.Lerp(y1, y2, Mathf.PingPong(Time.time * speed, 1)), 0);
    }
}
