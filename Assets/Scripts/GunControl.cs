using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    int shootable;
    public int damagePoint = 20;

    Ray ray;
    RaycastHit rayCastHit;

    public LineRenderer lineRenderer;
    public Light gunLight;

    public float gunDelayTime;
    float timer;

    void Start()
    {
        shootable = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        lineRenderer.SetPosition(0, transform.position);

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= gunDelayTime)
        {
            lineRenderer.enabled = true;
            gunLight.enabled = true;

            if (Physics.Raycast(ray, out rayCastHit, 1000f, shootable))
            {
                Debug.Log("Enemy shot");
                lineRenderer.SetPosition(1, rayCastHit.point);
                //shoot enemies

                EnemyHealth enemiesHealthManager = rayCastHit.collider.GetComponent<EnemyHealth>();

                if (enemiesHealthManager != null)
                {
                    enemiesHealthManager.TakeDamage(damagePoint, rayCastHit.point);
                }
            }
            else
            {
                lineRenderer.SetPosition(1, ray.origin + ray.direction);
            }
            timer = 0;
        }
        else
        {
            lineRenderer.enabled = false;
            gunLight.enabled = false;
        }
    }
}
