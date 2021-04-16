using System;
using Unity.Mathematics;
using UnityEngine;

namespace House
{
    public class ShootProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody projectile;
        [SerializeField] private GameObject cursor;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform shootPoint;

        private Camera camera;

        private void Awake()
        {
            camera = Camera.main;
        }

        private void Update()
        {
            LaunchProjectile();
        }

        private void LaunchProjectile()
        {
            Ray cameraRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit, 100f, layerMask))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;

                Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);
                transform.rotation = Quaternion.LookRotation(Vo);
                if (Input.GetMouseButtonDown(0))
                {
                    Rigidbody obj = Instantiate(projectile, shootPoint.position, quaternion.identity);
                    obj.velocity = Vo;
                }
            }
            else
            {
                cursor.SetActive(false);
            }
            
        }

        Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            // Define the distance x and y;
            Vector3 distance = target - origin;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0f;
            
            // Create Float representing distance
            float Sy = distance.y;
            float Sxz = distanceXZ.magnitude;

            float Vxz = Sxz / time;
            float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            Vector3 result = distanceXZ.normalized;
            result *= Vxz;
            result.y = Vy;
            return result;
        }
        
    }
}
