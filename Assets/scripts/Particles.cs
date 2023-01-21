using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject _particles;

    private void Start()
    {
        _particles.SetActive(false);
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        _particles.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        _particles.SetActive(false);
    }
}
