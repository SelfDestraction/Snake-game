using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Block))]
public class BlockNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Block _block;

    private void Awake()
    {
        _block = GetComponent<Block>();
    }

    private void OnEnable()
    {
        _block.FillingUpdated += OnFillingUpdated;
    }

    private void OnDisable()
    {
        _block.FillingUpdated -= OnFillingUpdated;
    }

    private void OnFillingUpdated(int LeftToFill)
    {
        _view.text = LeftToFill.ToString();
    }    
}
