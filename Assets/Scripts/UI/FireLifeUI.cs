using UnityEngine;
using UnityEngine.UI;

public class FireLifeUI : MonoBehaviour
{
    [SerializeField] private FireBehavior fireBehavior;
    [SerializeField] private Slider fireLifeSlider;

    void Awake()
    {
        fireBehavior.OnFireLifeChanged += UpdateFireLifeSlider;
    }

    private void UpdateFireLifeSlider(float fireLife)
    {
        fireLifeSlider.value = fireLife;
    }

    void OnDestroy()
    {
        fireBehavior.OnFireLifeChanged -= UpdateFireLifeSlider;
    }
}
