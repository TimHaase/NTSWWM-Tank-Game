using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    //bullet
    public GameObject bullet;

    //Spawnpoint of Bullet
    private Transform Bullet_Spawn = null;

    //Tank_Base
    public GameObject Tank = null;


    //bullet force
    public float shootForce;

    public float Power = 12.0f;

    //Gun stats
    public float timeBetweenShooting, spread, timeBetweeenShots;
    public int bulletsPerTap;


    //bools
    bool shooting, readyToShoot;

    //Reference
    public Transform attackPoint;

    //bug fixing
    public bool allowInvoke = true;


    void Start()
    {
        readyToShoot = true;
        Bullet_Spawn = transform.Find("Bullet_Spawn");
        Tank = GameObject.Find("Tank");
        
    }

        // Update is called once per frame
    void Update()
    {
        MyInput();
    }


    private void MyInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Space);

        //shooting
        if(readyToShoot && shooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet,
        Bullet_Spawn.position, Quaternion.identity);
        currentBullet.transform.Rotate(0,(Tank.transform.eulerAngles.y + 90) ,90);

        
        Rigidbody rb = currentBullet.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.velocity = Power * Bullet_Spawn.forward;
        

        
    }

 }

