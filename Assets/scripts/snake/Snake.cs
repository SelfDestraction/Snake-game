using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(SnakeGenerate))]
public class Snake : MonoBehaviour
{
    [SerializeField] private snakeHead _head;
    [SerializeField] private int _tailSize;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;
    [SerializeField] GameObject _gameOver;

    private List<Segment> _tail;
    private SnakeGenerate _tailGenerator;

    public event UnityAction<int> SizeUpdated;

    private void Awake()
    {
        _tailGenerator = GetComponent<SnakeGenerate>();
        
        _tail = _tailGenerator.Generate(_tailSize);
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.HealCollected += OnHealCollected;
    }

    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.HealCollected -= OnHealCollected;
    }

    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.forward * _speed * Time.fixedDeltaTime);
    }

    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _head.transform.position;

        foreach(var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector3.Lerp(segment.transform.position, previousPosition, _tailSpringiness * Time.deltaTime);
            previousPosition = tempPosition;
        }

        _head.Move(nextPosition);
    }

    private void OnBlockCollided()
    {
        Segment deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);
        SizeUpdated?.Invoke(_tail.Count);
        if(_tail.Count == 0)
        {
            _gameOver.SetActive(true);
            gameObject.SetActive(false);
        }
    }

private void OnHealCollected(int healSize)
    {
        _tail.AddRange(_tailGenerator.Generate(healSize));
        SizeUpdated?.Invoke(_tail.Count);
    }
}


