using System;
using System.Collections;
using Extensions.Object_Pooler;
using UnityEngine;

namespace House
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Joystick attackJoystick;
        [SerializeField] private float linePower = 2f;
        [SerializeField] private GameObject projectile;
        [SerializeField] private Transform attackLookAtPoint;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Transform player;
        [SerializeField] private Tag projectileTag;


        public Vector3[] bulletPoints;
        public float lineDistance;
        
        private RaycastHit hit;
        private bool isShoot;
        private void Awake()
        {
            lineRenderer.positionCount = 10;
            bulletPoints = new Vector3[9];
        }

        private void Update()
        {
            if (Mathf.Abs(attackJoystick.Horizontal) > 0.01f || Mathf.Abs(attackJoystick.Vertical) > 0.01f)
            {
                if (lineRenderer.gameObject.activeInHierarchy == false)
                {
                    lineRenderer.gameObject.SetActive(true);
                }
                
                transform.position = new Vector3(player.position.x, -1.54f, player.position.z);
                attackLookAtPoint.position = new Vector3(attackJoystick.Horizontal + player.position.x, -1.54f,
                    attackJoystick.Vertical + player.position.z);
                transform.LookAt(new Vector3(attackLookAtPoint.position.x, 0, attackLookAtPoint.position.z));
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

                lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
                
                for (int i = 1; i < 10; i++)
                {
                    lineRenderer.SetPosition(i, new Vector3(
                        lineRenderer.GetPosition(i - 1).x + attackJoystick.Horizontal / 2, i == 1? 0.35f : 
                            Mathf.Cos(linePower * (i * 0.1f)) * (i * 0.4f), 
                        lineRenderer.GetPosition(i - 1).z + attackJoystick.Vertical));
                    bulletPoints[i - 1] = lineRenderer.GetPosition(i) + transform.forward * 0.5f;
                }
                
                if (!isShoot)
                {
                    isShoot = true;
                }
            }
            else if (isShoot && Input.GetMouseButtonUp(0))
            {
                isShoot = false;
                objectPooler.SpawnFromPool(projectileTag, new Vector3(transform.position.x, 5f, transform.position.z),
                    transform.rotation);
                //Instantiate(projectile, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
            }
            else if (lineRenderer.gameObject.activeInHierarchy)
            {
                lineRenderer.gameObject.SetActive(false);
            }
        }
        public void PlayerShooting()
        {
            StartCoroutine(ShootProjectile());
        }

        private IEnumerator ShootProjectile()
        {
            Instantiate(projectile);
            yield return null;
        }
    }
}
