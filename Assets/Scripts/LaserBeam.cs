using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public LineRenderer laser;
    public float RotationSpeed = 20f;

    Vector2 dir, pos;

    GameObject LaserObj;
    List<Vector2> laserIndices = new List<Vector2>();

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -20 * Time.deltaTime);
        }
    }

    public LaserBeam(Vector2 pos, Vector2 dir, Material material)
    {
        this.laser = new LineRenderer();
        this.LaserObj = new GameObject();
        this.LaserObj.name = "Laser";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.LaserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.5f;
        this.laser.endWidth = 0.5f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.red;
    }
}
