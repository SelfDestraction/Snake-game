using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Player;
    public Vector3 Moveplayer;
    public float speed;
    public float zRage = 1f;
    void Update()
    {
        Vector3 targetPosition = Player.transform.position + Moveplayer;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

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
