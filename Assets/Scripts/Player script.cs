using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float moveSpeed = 9.0f; 
    private bool isMovingRight = false,isMovingLeft = false;
    [SerializeField] private LaserManager laserManager;
    private Gamemanager gameManager;
    [SerializeField] private AudioSource ExplosionAudio;



    // Start is called before the first frame update
    void Awake()
    {
        gameManager = Gamemanager.Instance; 
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartShooting();
        }
    }

    private void StartShooting()
    {
        Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 1); // Set the desired position
        Vector3 laserDirection = Vector3.up; // Set the desired direction
        laserManager.CreateLaser(laserPosition, laserDirection);
    }
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMovingRight = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMovingRight = false;
        }

        if (isMovingRight)
        {
            MoveRight();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMovingLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isMovingLeft = false;
        }

        if (isMovingLeft)
        {
            MoveLeft();
        }
    }
    private void MoveRight()
    {
        // Calculate the new position
        Vector3 newPosition = player.transform.position + Vector3.right * moveSpeed * Time.deltaTime;

        // Keep player in screen frame
        if (newPosition.x <8.3)
        {
            // Apply the new position to the player
            player.transform.position = newPosition;
        }
        
    }
    private void MoveLeft()
    {
        // Calculate the new position
        Vector3 newPosition = player.transform.position - Vector3.right * moveSpeed * Time.deltaTime;

        // Keep player in screen frame
        if (newPosition.x > -8.2)
        {
            // Apply the new position to the player
            player.transform.position = newPosition;
        }
    }

   

    private void OnCollisionEnter(Collision other)
    {
        gameManager.loseLife();
        ExplosionAudio.Play();
        Destroy(other.gameObject);
        Destroy(other.gameObject);
    }
}
