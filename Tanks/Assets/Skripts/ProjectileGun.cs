using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    //bullet
    public GameObject Bullet = null;

    //Spawnpoint of Bullet
    private Transform Bullet_Spawn = null;

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
        GameObject bullet = Instantiate(Bullet,
        Bullet_Spawn.position, Quaternion.identity);
        bullet.transform.Rotate(0,0,90);

        Rigidbody rb = bullet.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.velocity = Power * Bullet_Spawn.forward;

        StartCoroutine(RemoveBullet_Rigidbody(rb, 3.0f));
    }

    IEnumerator RemoveBullet_Rigidbody(Rigidbody rb, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(rb);
    }

 }

