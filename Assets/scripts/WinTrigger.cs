using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject _winTrigger;
    public GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _winTrigger.SetActive(true);
            _player.SetActive(false);
        }
    }
}
