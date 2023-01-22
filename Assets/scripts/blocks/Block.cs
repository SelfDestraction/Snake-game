using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;

    Color colorStart = Color.black;
    Color colorEnd = Color.white;
    Renderer rend;

    public int LeftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingUpdated;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingUpdated?.Invoke(LeftToFill);
    }

    private void Update()
    {
        float lerp = Mathf.PingPong(_filling, _destroyPrice) / _destroyPrice;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }

    public void Fill()
    {
        _filling++;
        FillingUpdated?.Invoke(LeftToFill);

        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }
}
