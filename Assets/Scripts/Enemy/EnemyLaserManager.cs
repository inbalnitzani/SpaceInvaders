using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserManager : MonoBehaviour
{
    [SerializeField] private float destroyYPosition = -10.0f;
    [SerializeField] private GameObject laserPrefab;

    [SerializeField] private AudioSource laserAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < destroyYPosition)
        {
            Destroy(gameObject);
        }
    }
    
    public void CreateLaser(Vector3 position, Vector3 direction)
    {
        GameObject laser = Instantiate(laserPrefab, position, laserPrefab.transform.rotation);
        laser.transform.up = -direction.normalized ;
        //laser.tag = "EnemyLaser";
        laserAudio.Play();

    }
}
