using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    private string[] lines;
    private int index;
    private bool isTyping;
    private bool isDialogueActive;

    public bool IsActive => isDialogueActive;

    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (lines != null && isDialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (isTyping)
                {
                    FinishTypingLine();
                }
                else if (index < lines.Length - 1)
                {
                    NextLine();
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    public void SetLines(string[] newLines)
    {
        lines = newLines;
    }

    public void ShowDialogue()
    {
        index = 0;
        textComponent.text = string.Empty;
        gameObject.SetActive(true);
        isDialogueActive = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }

    void FinishTypingLine()
    {
        StopAllCoroutines();
        textComponent.text = lines[index];
        isTyping = false;
    }

    void NextLine()
    {
        index++;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    void EndDialogue()
    {
        gameObject.SetActive(false);
        isDialogueActive = false;
        lines = null;
    }
}
