using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bullet;
    public Transform bulletspawnRight;
    public Transform bulletspawnLeft;
    private Camera mainCamera;
    private float LastFramePos;
    private bool MovingRight;
    public float shootDelay = 0.5f;
    private float timeSinceShot = 0f;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        MovePlayer();
        if(LastFramePos < gameObject.transform.position.x)
        {
            MovingRight = true;
        }
        else if(LastFramePos > gameObject.transform.position.x)
        {
            MovingRight = false;
        }
        LastFramePos = gameObject.transform.position.x;
        timeSinceShot += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceShot >= shootDelay)
        {
            
            Shoot();
            timeSinceShot = 0f;
            SoundManager.instance.PlaySound(0);

        }
    }

    void MovePlayer() //player movement
    {
        float moveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX,MoveY)*moveSpeed*Time.deltaTime;
        transform.Translate(movement);
        CameraClamp();
       
    }
    void Shoot()
    {
        if (MovingRight)
        {
            Instantiate(bullet, bulletspawnRight.position, bulletspawnRight.rotation);
        }
        else
        {
            GameObject bulletprefab= Instantiate(bullet, bulletspawnLeft.position, bulletspawnLeft.rotation);
            bulletprefab.GetComponent<Bullets>().speed *= -1;
        }
         //generate bullet
    }

    //get and clamp player based on camera
    void CameraClamp()
    { //get the bounds
        float screenWidth = mainCamera.orthographicSize*((float)Screen.width/Screen.height);
        float screenHeight = mainCamera.orthographicSize;
        //clamp the player
        float clampX = Mathf.Clamp(transform.position.x, -screenWidth, screenWidth);
        float clampY = Mathf.Clamp(transform.position.y, -screenHeight, screenHeight);
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}
