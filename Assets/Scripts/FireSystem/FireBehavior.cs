using UnityEngine;
public class FireBehavior : MonoBehaviour
{
    [SerializeField]private float fireLife = 1.0f;
    private bool isBeingExtinguished = false;
    private ParticleSystem fireParticleSystem;

    void Start()
    {
        fireParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (isBeingExtinguished)
        {
            fireLife -= Time.deltaTime / 6.0f;
            fireLife = Mathf.Max(fireLife, 0.0f);
        }
        else
        {
            fireLife += Time.deltaTime / 10.0f;
            fireLife = Mathf.Min(fireLife, 1.0f);
        }

        UpdateFireVisual();
    }

    public void StartExtinguishing()
    {
        isBeingExtinguished = true;
    }

    public void StopExtinguishing()
    {
        isBeingExtinguished = false;
    }

    private void UpdateFireVisual()
    {
        var main = fireParticleSystem.main;
        main.startSize = Mathf.Lerp(0.5f, 1.0f, fireLife);
        main.startColor = Color.Lerp(Color.gray, Color.red, fireLife);
    }
}