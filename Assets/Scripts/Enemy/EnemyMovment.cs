using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f; 
    [SerializeField] private float movementRange = 2.0f; 

    private int direction = 1; // 1 for right, -1 for left
    private float initialX;

    [SerializeField] private float rotationSpeed = 90.0f; 
    private Quaternion initialRotation = Quaternion.Euler(270, 155.6f, 0);

     private Gamemanager gameManager;
    private void Awake()
    {
        initialX = transform.position.x;
        gameManager = Gamemanager.Instance; 
     
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Move the enemy horizontally
        Vector3 newPosition = transform.position + Vector3.right * direction * moveSpeed * Time.deltaTime;
        transform.position = newPosition;
      
        // Calculate the new y rotation based on direction
        float targetRotationY = direction == 1 ? initialRotation.eulerAngles.y - 280.0f : initialRotation.eulerAngles.y + 360.0f;

        // Rotate the enemy towards the new y rotation
        Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles.x, targetRotationY, initialRotation.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        // Check if the enemy has moved beyond the allowed range
        if (Mathf.Abs(transform.position.x - initialX) > movementRange)
        {
            // Change direction
            direction *= -1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            gameManager.destroyEnemy();
            Destroy(gameObject);
        }
    }
        
}