using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class PowerupBase : MonoBehaviour
{
    [Header("FX")]
    [SerializeField] private GameObject _artToHide;
    [SerializeField] private Collider _colliderToDisable;
    [Space]
    [Header("Numbers")]
    [SerializeField] protected float powerupTimeMaximum; //The amount of time the powerup is active
                     protected float powerupTimeCurrent; //The amount of time that the powerup has been active
                     protected bool powerupTimerStarted = false; //Whether or not the powerup has been activated yet
    
    
    protected abstract void PowerUp();
    protected abstract void PowerDown();


    protected TurretController turrentController;

    private void Awake()
    {
        turrentController = FindObjectOfType<TurretController>();
    }

    private void Start()
    {
        powerupTimeCurrent = powerupTimeMaximum;
    }

    protected virtual void Update()
    {
        if(powerupTimerStarted)
        {
            if (powerupTimeCurrent > 0)
            {
                powerupTimeCurrent -= Time.deltaTime;
            }
            else
            {
                PowerDown();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Projectile projectile = other.GetComponent<Projectile>();
        if (projectile != null)
        {
            OnHit();
        }
    }

    protected virtual void OnHit()
    {
        powerupTimeCurrent = powerupTimeMaximum;
        _colliderToDisable.enabled = false;
        _artToHide.SetActive(false);
        powerupTimerStarted = true;

        PowerUp();
    }
}
