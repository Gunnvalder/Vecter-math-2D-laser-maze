using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float RotationSpeed = 20f;
    public float laserSpeed = 10f;
    public int maxReflections = 5;

    private Vector2 direction;

    private void Start()
    {
        direction = transform.up;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime);
        }

        UpdateLaserPath();
    }

    void UpdateLaserPath()
    {
        Vector2 laserStart = (Vector2)transform.position;
        Vector2 laserEnd = laserStart + direction * laserSpeed;
    }
}
