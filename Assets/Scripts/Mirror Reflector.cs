using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorReflector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            LaserManager laser = other.GetComponent<LaserManager>();

            if (laser != null)
            {
                Vector2 MirrorNormal = transform.up;

                Vector2 IncomingDirection = (Vector2)(laser.transform.position - other.transform.position).normalized;

                Vector2 ReflectionDirection = Vector2.Reflect(IncomingDirection, MirrorNormal);

                laser.SetDirection(ReflectionDirection);
            }
        }
    }
}
