using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     private float _currentSpeed;
     private Vector3 _lastPosition;
     public float GetCurrentSpeed()
     {
          var position = transform.position;
          _currentSpeed = Mathf.Lerp(_currentSpeed, (position - _lastPosition).magnitude / Time.deltaTime,
               0.75f);
          _lastPosition = position;

          return _currentSpeed;
     }

     public void RotateTowards(Vector3 targetPosition, float rotationSpeed)
     {
          Vector3 direction = (targetPosition - transform.position).normalized;
          Quaternion lookRotation = Quaternion.LookRotation(direction);
          transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
     }
}
