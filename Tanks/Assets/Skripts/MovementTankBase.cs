using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTankBase : MonoBehaviour
{
    private float speed = 10;
    private float rotateSpeed = 75;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float z_movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, 0, z_movement);
        transform.Rotate(0, x_movement, 0);
    }
}
