using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controll : MonoBehaviour
{
    public float horizontalInput;
    [SerializeField] private float speed = 10.0f;
    public float zRage = 4.4f;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);


        if (transform.position.z < -zRage)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRage);
        }
        if (transform.position.z > zRage)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRage);
        }
    }
}
