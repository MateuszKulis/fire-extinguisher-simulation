using System;
using UnityEngine;

public class Extinguisher : MonoBehaviour
{
    [SerializeField] private FireBehavior targetFire;
    [SerializeField] private ParticleSystem extinguishingParticleSystem;
    [SerializeField] private AnimationController tipCameraAnimation;
    [SerializeField] private GameObject tipUI;
    [SerializeField] private GameObject cameraTipUI;
    [HideInInspector] public bool isSafetyPinRemoved = false;
    [HideInInspector] public bool isNozzleAvailable = false;
    private bool isExtinguishing = false;
    private float extinguisherPowderRemaining = 10.0f;

    public event Action<float> OnPowderRemainingChanged;

    void Update()
    {
        if (isExtinguishing)
        {
            extinguisherPowderRemaining -= Time.deltaTime;
            if (extinguisherPowderRemaining <= 0.0f)
            {
                extinguisherPowderRemaining = 0.0f;
                StopExtinguishing(); 
            }

            OnPowderRemainingChanged?.Invoke(extinguisherPowderRemaining); 

            if (Input.GetMouseButtonUp(0))
            {
                StopExtinguishing();
            }
        }
        if (isSafetyPinRemoved)
        {
            tipCameraAnimation.PlayAnimation("CameraTip2");
        }
        if (isNozzleAvailable)
        {
            tipUI.SetActive(true);
            cameraTipUI.SetActive(false);
        }
    }

    public void HandleClicked()
    {
        if (!isExtinguishing && isSafetyPinRemoved && extinguisherPowderRemaining > 0.0f)
        {
            StartExtinguishing();
        }
    }

    private void StartExtinguishing()
    {
        isExtinguishing = true;
        targetFire.StartExtinguishing();
        extinguishingParticleSystem.Play();
    }

    private void StopExtinguishing()
    {
        isExtinguishing = false;
        targetFire.StopExtinguishing();
        extinguishingParticleSystem.Stop();
    }

    public float GetExtinguisherPowderRemaining()
    {
        return extinguisherPowderRemaining;
    }
}
