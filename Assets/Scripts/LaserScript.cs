using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Transform LaserTarget;  //the lasers target
    public float speed = 5f;       //how fast the laser moves 
    public float timeLimit = 200f;  //the time limit to hit the target
    private Vector2 direction;     //the direction of the laser
    private float timeRemaining;   //Timer for the countdown
    private Transform startPoint;

    public TextMeshProUGUI TimerText;

    public LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        if (lineRenderer.startWidth == 0)
        {
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }

        if (lineRenderer.material == null)
        {
            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = Color.red;
        }

        lineRenderer.SetPosition(0, transform.position);

        direction = (LaserTarget.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        HandleLaserControl();

        timeRemaining -= Time.deltaTime;

        TimerText.text = "Time: " + Mathf.Max(0, Mathf.RoundToInt(timeRemaining)).ToString();

        transform.position += (Vector3)direction * speed * Time.deltaTime;

        direction = (LaserTarget.position - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        if (hit.collider != null)
        {
            // Laser hits something, show hit point
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Laser does not hit anything, extend it further
            lineRenderer.SetPosition(1, transform.position + (Vector3)direction * 10f);
        }

        lineRenderer.SetPosition(0, transform.position);
    }

    private void HandleLaserControl()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, rotationInput * rotationSpeed * Time.deltaTime);
    }
}
