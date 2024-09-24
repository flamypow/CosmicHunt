using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public GameObject laserPrefab;
    public Transform laserSpawnPoint;
    public float shootInterval = 2f;
    public float loopRange = 1f;
    public float loopFrequency = 2f;
    
    private float minY, maxY;
    private Vector3 startPosition;
    private float shootTimer;
    

    void Start()
    {
        startPosition = transform.position;
        shootTimer = shootInterval;
        CameraBounds();
       
    }

    void Update()
    {
        MoveEnemy();
        ShootPlayer();
    }

    void MoveEnemy()
    {
      float newY= startPosition.y + Mathf.Sin(Time.time*loopFrequency)*loopRange;
        newY = Mathf.Clamp(newY, minY, maxY);
        transform.position = new Vector3(startPosition.x, newY, 0);
    }

    void ShootPlayer()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer <= 0)
        {
            Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
            shootTimer = shootInterval;
        }
    }

    void CameraBounds() //trying to get camera limits positions and clamp
    {
        Camera cam = Camera.main;
        //getting screen corner
        Vector3 bottomLeftCam = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRightCam = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        //setting min and max values based on camera
        
        minY = bottomLeftCam.y;
        maxY = topRightCam.y;
    }
}
