using System;
using Unity.VisualScripting;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private AudioSource laserAudio;


    public void CreateLaser(Vector3 position, Vector3 direction)
    {
        GameObject laser = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser.transform.up = direction.normalized; 
        laserAudio.Play();
        
    }

 
}