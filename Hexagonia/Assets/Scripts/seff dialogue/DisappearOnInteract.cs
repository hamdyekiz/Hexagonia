using UnityEngine;

public class DisappearOnInteract : MonoBehaviour, IInteractable
{
    public GameObject objectToDisappear; 

    public void Interact()
    {
        Debug.Log("Interacting with: " + gameObject.name); 

        if (objectToDisappear != null)
        {
            objectToDisappear.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No object assigned to disappear in " + gameObject.name);
        }
    }
}
