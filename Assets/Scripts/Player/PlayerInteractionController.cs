using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private Interactable _closestInteractable;
    private float _closestInteractableDistance;

    // Start is called before the first frame update
    void Start()
    {
        _closestInteractable = null;
        _closestInteractableDistance = 10000f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 playerPosition = transform.position;

            Interactable[] interactables = FindObjectsOfType<Interactable>();
            foreach (Interactable interactable in interactables)
            {
                float interactableDistance =
                    Vector3.Distance(interactable.GetComponent<Transform>().position, playerPosition);
                
                if (_closestInteractable == null)
                {
                    setInteractableAsClosest(interactable, interactableDistance);
                    continue;
                }
                
                if (interactableDistance < _closestInteractableDistance)
                {
                    _closestInteractable = interactable;
                    _closestInteractableDistance = interactableDistance;
                }
            }

            if (_closestInteractableDistance < _closestInteractable.radius)
            {
                _closestInteractable.OnInteract();
            }
        }
    }

    private Interactable setInteractableAsClosest(Interactable interactable, float interactableDistance)
    {
        _closestInteractable = interactable;
        _closestInteractableDistance = interactableDistance;
    }
}
