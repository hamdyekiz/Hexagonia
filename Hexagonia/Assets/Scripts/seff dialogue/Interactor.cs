using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");

            Collider closestInteractable = null;
            float closestDistance = InteractRange;

            Collider[] hitColliders = Physics.OverlapSphere(InteractorSource.position, InteractRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Interactable"))
                {
                    if (hitCollider.gameObject.TryGetComponent(out IInteractable interactable))
                    {
                        float distance = Vector3.Distance(InteractorSource.position, hitCollider.transform.position);
                        if (distance < closestDistance)
                        {
                            closestInteractable = hitCollider;
                            closestDistance = distance;
                        }
                    }
                }

                if (hitCollider.gameObject.name == "Wing6")
                {
                    Debug.DrawLine(InteractorSource.position, hitCollider.transform.position, Color.red, 2f);
                }
                else
                {
                    Debug.DrawLine(InteractorSource.position, hitCollider.transform.position, Color.yellow, 2f);
                }
            }

            if (closestInteractable != null)
            {
                Debug.Log("Interacting with: " + closestInteractable.gameObject.name);
                closestInteractable.gameObject.GetComponent<IInteractable>().Interact();
            }
            else
            {
                Debug.Log("No interactable objects within range");
            }
        }
    }
}
