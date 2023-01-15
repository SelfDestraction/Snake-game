using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class snakeHead : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public event UnityAction BlockCollided;
    public event UnityAction<int> HealCollected;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 newPosition)
    {
        _rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            BlockCollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out Heal heal))
        {
            HealCollected?.Invoke(heal.Collect());
        }
    }
}
