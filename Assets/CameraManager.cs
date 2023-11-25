using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   public Transform targetTransform;
   private Vector3 cameraFollowVelocity = Vector3.zero;
   public float cameraFollowSpeed = 0.2f;
   private void Awake()
   {
    targetTransform = FindAnyObjectByType<PlayerManager>().transform;
   }
   public void FolllowTaget()
   {
    Vector3 targetPosition = Vector3.SmoothDamp(transform.position,targetTransform.position,ref cameraFollowVelocity,cameraFollowSpeed);
   transform.position = targetPosition;
   }
}
