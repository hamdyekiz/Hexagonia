using UnityEngine;

public class DelayedDialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue;
    public string[] lines;
    public float delay = 2f; 

    public void Interact()
    {
        Invoke("ShowDialogue", delay);
    }

    void ShowDialogue()
    {
        dialogue.SetLines(lines);
        dialogue.ShowDialogue();
    }
}
