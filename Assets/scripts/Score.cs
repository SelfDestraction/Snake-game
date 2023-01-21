using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private TMP_Text _score;

    private void Update()
    {
        _score.text = ((int) (-_player.position.x / 2)).ToString();
    }
}
