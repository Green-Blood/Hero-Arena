using System;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace House
{
    public class ShootProjectile : MonoBehaviour
    {

        [Title("Projectile")]
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float shootDelay = 1f;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Tag projectileTag;
        
        [Title("Cursor")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject cursor;
       
        
       
        

        private Camera _camera;
        private float _delayTime;

        private void Awake()
        {
            _camera = Camera.main;
            _delayTime = Time.time + shootDelay;
        }

        private void Update()
        {
            LaunchProjectile();
        }

        private void LaunchProjectile()
        {
            Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit, 100f, layerMask))
            {
                cursor.SetActive(true);
                cursor.transform.position = hit.point + Vector3.up * 0.1f;

                Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 1f);
                transform.rotation = Quaternion.LookRotation(Vo);
                
                if (!(Time.time > _delayTime)) return;
                if (Input.GetMouseButtonUp(0))
                {
                    GameObject obj =
                        objectPooler.SpawnFromPool(projectileTag, shootPoint.position, Quaternion.identity);
                    obj.GetComponentInChildren<Rigidbody>().velocity = Vo;
                    _delayTime = Time.time + shootDelay;
                }
            }
            else
            {
                cursor.SetActive(false);
            }
            
        }

        private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
        {
            // Define the distance x and y;
            var distance = target - origin;
            var distanceXZ = distance;
            //distanceXZ.Normalize();
            distanceXZ.y = 0f;
            
            // Create Float representing distance
            float distanceY = distance.y;
            float distanceXZMagnitude = distanceXZ.magnitude;

            // Calculate initial x Velocity 
            // Vx = x / t 
            float xzVelocity = distanceXZMagnitude / time;
            
            // Calculate initial y Velocity 
            // Vy0 = y / t + 1/2 * g * t
            float yVelocity = distanceY / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

            // Calculate result
            Vector3 result = distanceXZ.normalized;
            result *= xzVelocity;
            result.y = yVelocity;
            return result;
        }
        
    }
}
