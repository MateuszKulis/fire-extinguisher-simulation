using UnityEngine;
public class Extinguisher : MonoBehaviour
{
    [SerializeField]private FireBehavior targetFire;
    [SerializeField]private ParticleSystem extinguishingParticleSystem;
    [HideInInspector]public bool isSafetyPinRemoved = false;
    private bool isExtinguishing = false;

    void Update()
    {
        if (isExtinguishing && Input.GetMouseButtonUp(0))
        {
            StopExtinguishing();
        }
    }

    public void HandleClicked()
    {
        if (!isExtinguishing && isSafetyPinRemoved)
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
}
