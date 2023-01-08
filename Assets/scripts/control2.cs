using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control2 : MonoBehaviour
{
    public Transform Player;
    public float Sensitivity;
    public float zRage = 4.4f;
    [SerializeField]
    private float speed = 10f;

    private Vector3 _previousMouseposition;

    void Update()
    {
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMouseposition;
            Player.Translate(delta.x * Sensitivity, 0, 0);

            if (transform.position.z < -zRage)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRage);
            }
            if (transform.position.z > zRage)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRage);
            }
        }
        _previousMouseposition = Input.mousePosition;
    }
}
