using UnityEngine;

public class GravityControlOnInteract : MonoBehaviour, IInteractable
{
    public GameObject objectToControl;
    private Rigidbody objectRigidbody;

    void Start()
    {

        objectRigidbody = objectToControl.GetComponent<Rigidbody>();
        if (objectRigidbody == null)
        {
            Debug.LogError("No Rigidbody found on " + objectToControl.name);
        }
        else
        {
            objectRigidbody.isKinematic = false;
        }
    }

    public void Interact()
    {
        if (objectRigidbody != null)
        {
            objectRigidbody.useGravity = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }
    }
}