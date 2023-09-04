using System;
using Unity.VisualScripting;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
     private float destroyYPosition = 7.0f; 
     private float speed = 22f;

  

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
        
        if (transform.position.y > destroyYPosition)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}