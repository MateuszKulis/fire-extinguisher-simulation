using UnityEngine;
using System;

public class FireBehavior : MonoBehaviour
{
    [SerializeField] private float fireLife = 1.0f;
    private bool isBeingExtinguished = false;
    private ParticleSystem fireParticleSystem;

    public event Action<float> OnFireLifeChanged;

    void Start()
    {
        fireParticleSystem = GetComponent<ParticleSystem>();
        UpdateFireVisual(); 
        OnFireLifeChanged?.Invoke(fireLife); 
    }

    void Update()
    {
        if (isBeingExtinguished)
        {
            fireLife -= Time.deltaTime / 6.0f; 
        }
        else
        {
            fireLife += Time.deltaTime / 10.0f; 
        }

        fireLife = Mathf.Clamp(fireLife, 0.0f, 1.0f);
        UpdateFireVisual();
        OnFireLifeChanged?.Invoke(fireLife); 

        if (fireLife <= 0.0f)
        {
            ExtinguishFire();
        }
    }

    private void UpdateFireVisual()
    {
        var main = fireParticleSystem.main;
        main.startSize = Mathf.Lerp(3f, 17f, fireLife); 
        if (fireLife <= 0.0f && fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Stop();
        }
        else if (fireLife > 0.0f && !fireParticleSystem.isPlaying)
        {
            fireParticleSystem.Play();
        }
    }

    private void ExtinguishFire()
    {

    }

    public void StartExtinguishing()
    {
        isBeingExtinguished = true;
    }

    public void StopExtinguishing()
    {
        isBeingExtinguished = false;
    }
}
