using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bullet;
    public Transform bulletspawn;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        CameraBounds();
    }
    void Update()
    {
        MovePlayer();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void MovePlayer() //player movement
    {
        float moveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + new Vector3(moveX*moveSpeed*Time.deltaTime, MoveY*moveSpeed*Time.deltaTime, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
    void Shoot()
    {
        Instantiate(bullet, bulletspawn.position,bulletspawn.rotation); //generate bullet
    }

    void CameraBounds() //trying to get camera limits positions and clamp
    {
        Camera cam = Camera.main;
        //getting screen corner
        Vector3 bottomLeftCam =  cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRightCam = cam.ViewportToWorldPoint(new Vector3(1,1, cam.nearClipPlane));

        //setting min and max values based on camera
        minX = bottomLeftCam.x;
        maxX = topRightCam.x;
        minY = bottomLeftCam.y;
        maxY = topRightCam.y;
    }
}
