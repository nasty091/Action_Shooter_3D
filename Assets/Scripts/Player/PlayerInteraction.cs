using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private List<Interactable> interactables = new List<Interactable>();

    private Interactable closestInteractable;

    private void Start()
    {
        Player player = GetComponent<Player>();

        player.controls.Character.Interaction.performed += context => InteractWithClosest();
    }

    private void InteractWithClosest()
    {
        closestInteractable?.Interaction();
        interactables.Remove(closestInteractable);

        UpdateClosestInteractable();
    }

    public void UpdateClosestInteractable()
    {
        closestInteractable?.HighLightActive(false);

        closestInteractable = null;
        float closesDistance = float.MaxValue;

        foreach (Interactable interactable in interactables)
        {
            float distance = Vector3.Distance(transform.position, interactable.transform.position);

            if (distance < closesDistance)
            {
                closesDistance = distance;
                closestInteractable = interactable;
            }
        }

        closestInteractable?.HighLightActive(true);
    }

    public List<Interactable> GetInteractables() => interactables;
}
