using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 playerPosition = transform.position;
            Interactable closestInteractable = null;
            var closestInteractableDistance = 10000f;

            Interactable[] interactables = FindObjectsOfType<Interactable>();
            foreach (Interactable interactable in interactables)
            {
                float interactableDistance =
                    Vector3.Distance(interactable.GetComponent<Transform>().position, playerPosition);
                
                if (closestInteractable == null)
                {
                    closestInteractable = interactable;
                    closestInteractableDistance = interactableDistance;
                    continue;
                }
                
                if (interactableDistance < closestInteractableDistance)
                {
                    closestInteractable = interactable;
                    closestInteractableDistance = interactableDistance;
                }
            }

            if (closestInteractableDistance < closestInteractable.radius)
            {
                closestInteractable.OnInteract();
            }
        }
    }
}