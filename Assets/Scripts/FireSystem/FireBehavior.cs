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