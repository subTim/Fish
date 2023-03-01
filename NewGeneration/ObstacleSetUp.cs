 using System;
 using UnityEngine;
 using Random = UnityEngine.Random;

 public class ObstacleSetUp : MonoBehaviour
 {
     [SerializeField] private float yBaseOffset;
     
     [SerializeField,Range(0,180)] private int maxRotationY;
     [SerializeField,Range(0,180)] private int minRoatationY;
     
     [SerializeField,Range(0,180)] private int maxRotationX;
     [SerializeField,Range(0,180)] private int minRoatationX;
     

     [SerializeField,Range(0f,5f)] private float maxOffsetX;
     [SerializeField,Range(0f,5f)] private int minOffsetX;
     
     [SerializeField,Range(0f,5f)] private float maxOffsetY;
     [SerializeField,Range(0f,5f)] private int minOffsetY;
     
     [SerializeField,Range(0f,5f)] private float maxOffsetZ;
     [SerializeField,Range(0f,5f)] private int minOffsetZ;
     private void Awake()
     {
         SetOffset();
         SetRotation();
     }

     private void SetRotation()
     {
         var rotation = gameObject.transform.rotation;
         
         rotation.y = Random.Range(minRoatationY, maxRotationY);
         rotation.x = Random.Range(minRoatationX, maxRotationX);

         gameObject.transform.rotation = rotation;
     }

     private void SetOffset()
     {
         var pos = gameObject.transform.position;
         
         pos.x = Random.Range(minOffsetX, maxOffsetX);
         pos.y = Random.Range(minOffsetY, maxOffsetY) + yBaseOffset;
         pos.z = Random.Range(minOffsetZ, maxOffsetZ);

         gameObject.transform.position = pos;
     }
 }