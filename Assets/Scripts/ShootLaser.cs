using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    LaserBeam beam;

    private void Start()
    {
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
    }

    // Update is called once per frame
    void Update()
    {
        if (beam != null)
        {
            Destroy(GameObject.Find("Laser"));
            beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
        }
    }
}
