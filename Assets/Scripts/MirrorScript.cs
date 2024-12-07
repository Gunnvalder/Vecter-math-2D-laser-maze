using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScript : MonoBehaviour
{
    public Transform LaserSource;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(LaserSource.position, direction);
        if (hit.collider != null && hit.collider.CompareTag("Mirror"))
        {
            Vector2 normal = hit.normal; // Get the normal vector of the mirror
            direction = Vector2.Reflect(direction, normal); // Reflect the direction
        }
    }
}
