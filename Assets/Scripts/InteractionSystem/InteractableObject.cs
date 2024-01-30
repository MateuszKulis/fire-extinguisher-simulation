using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private enum InteractionType { SafetyPin, Nozzle, Handle }
    [SerializeField] private InteractionType interactionType;
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Extinguisher extinguisher;
    [SerializeField] private bool isCursorOver = false;

    void OnMouseEnter()
    {
        isCursorOver = true;
    }

    void OnMouseExit()
    {
        isCursorOver = false;
    }

    public void OnMouseDown()
    {
        if (!isCursorOver) return;

        switch (interactionType)
        {
            case InteractionType.SafetyPin:
                animationController.PlayAnimation("UnlockingExtinguisher");
                extinguisher.isSafetyPinRemoved = true;
                break;
            case InteractionType.Nozzle:
                if (extinguisher.isSafetyPinRemoved)
                {
                    animationController.PlayAnimation("NozzleSettingExtinguisher");
                }
                break;
            case InteractionType.Handle:
                if (extinguisher.isSafetyPinRemoved)
                {
                    extinguisher.HandleClicked();
                }
                break;
        }
    }
}
