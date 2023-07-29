using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;


public class DialogueFloor : MonoBehaviour
{
    public Dialogue dialogue;
    public LocalizedString[] localizedDialogues;

    void Start()
    {
        if (dialogue == null)
        {
            dialogue = FindObjectOfType<Dialogue>();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowLocalizedDialogues());
        }
    }

    IEnumerator ShowLocalizedDialogues()
    {
        for (int i = 0; i < localizedDialogues.Length; i++)
        {
            string[] dialogueLines = GetLocalizedDialogueLines(localizedDialogues[i]);
            if (dialogueLines != null && dialogueLines.Length > 0)
            {
                dialogue.SetLines(dialogueLines);
                dialogue.ShowDialogue();

                while (dialogue.IsActive)
                {
                    yield return null;
                }
            }
        }
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
