using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SnakeNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        _snake.SizeUpdated += OnSizeUpdated;
    }

    private void OnDisable()
    {
        _snake.SizeUpdated -= OnSizeUpdated;
    }
private void OnSizeUpdated(int Size)
    {
        _view.text = Size.ToString();
    }
}
