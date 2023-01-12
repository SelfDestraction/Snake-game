using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface Ihealth
{
    void ChangeHP(int value);
}

public abstract class BlockEater : MonoBehaviour
{
    public event Action<int> HPUpdate;

    [SerializeField] private int _HP;
    public int Health=> _HP;

    protected virtual void ChangeHP(Ihealth health) { }

    private void Start()
    {
        HealthUpdate(_HP);
    }

    private void OnCollisionStay(Collision collision)
    {
        var health=collision.gameObject.GetComponent<Ihealth>();
        if (health != null)
        {
            ChangeHP(health);
        }
    }

    protected void HealthUpdate(int value)
    {
        HPUpdate?.Invoke(value);
    }
}
