using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : PlayerMove
{
    public static GameObject target;
    public float angle = 0.0f;
    public float radius = 2.0f;
    public GameObject center = null;

    void Start()
    {

    }

    private void Update()
    {
        this.transform.position = RotateAroundY(this.center.transform.position, this.angle, this.radius);
        this.angle += 0.01f;
    }
    static Vector3 RotateAroundY(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.z += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(a) * v.x + Mathf.Sin(a) * v.z;
        float y = v.y;
        float z = -Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.z;
        return new Vector3(x, y, z);
    }


}