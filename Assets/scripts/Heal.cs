using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private Vector2Int _SizeRange;

    private int _healSize;

    private void Start()
    {
        _healSize = Random.Range(_SizeRange.x, _SizeRange.y);
        _view.text = _healSize.ToString();
    }

    public int Collect()
    {
        Destroy(gameObject);
        return _healSize;
    }

}
