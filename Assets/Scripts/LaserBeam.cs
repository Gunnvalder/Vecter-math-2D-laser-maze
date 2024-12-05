using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam 
{

    Vector2 dir, pos;

    GameObject LaserObj;
    LineRenderer laser;
    List<Vector2> laserIndices = new List<Vector2>();

    public LaserBeam(Vector2 pos, Vector2 dir, Material material)
    {
        this.laser = new LineRenderer();
        this.LaserObj = new GameObject();
        this.LaserObj.name = "Laser";
        this.pos = pos;
        this.dir = dir;

        this.laser = this.LaserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.laser.startWidth = 0.1f;
        this.laser.endWidth = 0.1f;
        this.laser.material = material;
        this.laser.startColor = Color.green;
        this.laser.endColor = Color.green;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30,1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    private void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (Vector2 idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector2 direction, LineRenderer laser)
    {
        if (hitInfo.collider.gameObject.tag == "mirror")
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector2.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }
}
