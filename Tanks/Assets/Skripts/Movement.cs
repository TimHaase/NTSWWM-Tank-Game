using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z_movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x_movement, 0, z_movement);
    }
}
