using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    

    private float nextShootTime;
    
   private EnemyLaserManager laserManager;

   private void Awake()
   {
       laserManager = FindObjectOfType<EnemyLaserManager>();
       // Initialize nextShootTime with a random time within the specified range
       nextShootTime = Time.time + Random.Range(0f,20f);
   }

   private void Start()
    {
        

    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            // shoot every 20 sec 
            Shoot();
            nextShootTime = Time.time + 20.0f;

        }
    }

    private void Shoot()
    {
        
        Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y - 1 , transform.position.z + 1); // Set the desired position
        Vector3 laserDirection = Vector3.down; // Set the desired direction
        laserManager.CreateLaser(laserPosition, laserDirection);
    }
}
