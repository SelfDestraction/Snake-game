using UnityEngine;
using TMPro;

public class BlickUI: MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private BlockEater _block;

    private void Awake()
    {
        _block = GetComponent<BlockEater>();
    }

    private void OnEnable()
    {
        _block.HPUpdate += HPUpdate;
    }

    private void OnDisable()
    {
        _block.HPUpdate += HPUpdate;
    }

    private void HPUpdate(int value)
    {
        _text.text=value.ToString();
    }
}