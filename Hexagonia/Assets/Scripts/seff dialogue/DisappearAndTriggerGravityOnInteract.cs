using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class DisappearAndTriggerGravityOnInteract : MonoBehaviour, IInteractable
{
    public GravityControlOnInteract gravityController; 
    public Dialogue dialogue;
    public LocalizedString[] localizedDialogues;
    public float delay = 1f; 

    private Renderer objectRenderer; 
    private bool isInteracted = false; 

    [SerializeField]
    private GameObject objectToDisappear; 
    private void Start()
    {
        if (gravityController == null)
        {
            Debug.LogError("No GravityControlOnInteract script assigned to " + gameObject.name);
        }

        objectRenderer = GetComponent<Renderer>();
    }

    public void Interact()
    {
        if (!isInteracted)
        {
            isInteracted = true;
            Debug.Log("Interacting with: " + gameObject.name);

            objectRenderer.enabled = false;

            if (gravityController != null)
            {
                gravityController.Interact();
            }

            StartCoroutine(ShowLocalizedDialogues());

            gameObject.SetActive(false);

            if (objectToDisappear != null)
            {
                objectToDisappear.SetActive(false);
            }
        }
    }

    IEnumerator ShowLocalizedDialogues()
    {
        for (int dialogueIndex = 0; dialogueIndex < localizedDialogues.Length; dialogueIndex++)
        {
            string[] dialogueLines = GetLocalizedDialogueLines(localizedDialogues[dialogueIndex]);
            if (dialogueLines != null && dialogueLines.Length > 0)
            {
                for (int lineIndex = 0; lineIndex < dialogueLines.Length; lineIndex++)
                {
                    dialogue.SetLines(new string[] { dialogueLines[lineIndex] });
                    dialogue.ShowDialogue();

                    while (dialogue.IsActive)
                    {
                        yield return null;
                    }

                    yield return new WaitForSeconds(delay); 
                }
            }
        }

        gameObject.SetActive(false);
        isInteracted = false;
    }




    private string[] GetLocalizedDialogueLines(LocalizedString localizedDialogue)
    {
        var locale = LocalizationSettings.SelectedLocale;
        var localizedValue = localizedDialogue.GetLocalizedString(locale);
        if (!string.IsNullOrEmpty(localizedValue))
        {
            return localizedValue.Split('\n');
        }
        return null;
    }
}
