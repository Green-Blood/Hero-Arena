using Enemy;
using UnityEngine;

namespace House
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage = 10f;
        [SerializeField] private Tag enemyTag;
        
        private Shoot _shoot;
        private Vector3[] _points;
        private int _currentIndex;
        private Rigidbody _rigidbody;
        

        private void Start()
        {
            _shoot = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
            _points = new Vector3[9];
            
            _shoot.bulletPoints.CopyTo(_points, 0);
            _rigidbody = transform.GetComponent<Rigidbody>();
          
          }

        private void Update()
        {
         
            transform.Translate(Vector3.forward * speed);
            if (!((_points[_currentIndex] - transform.position).sqrMagnitude < 0.2f)) return;
            if (_currentIndex == 8) _rigidbody.useGravity = true;
            else
            {
                _currentIndex++;
                transform.LookAt(_points[_currentIndex]);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.HasTag(enemyTag))
            {
                other.collider.GetComponent<Health>().TakeDamage(damage);
                gameObject.SetActive(false);
            }
            else
            {
               // gameObject.SetActive(false);
            }
        }
    }
}
