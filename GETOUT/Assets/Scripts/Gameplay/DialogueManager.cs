using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] int lettersPerSecond;
    public event Action OnShowDialog;
    public event Action OnCloseDialog;
    public static DialogueManager Instance{get; private set;}
    private void Awake()
    {
        Instance=this;
    }
    Dialog dialog;
    int currentLine = 0;
    bool isTyping;

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();
        this.dialog=dialog;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void HandleUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if(currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                currentLine=0;
                dialogBox.SetActive(false);
                OnCloseDialog?.Invoke();
            }
        }
    }
    public IEnumerator TypeDialog(string Lines)
    {
        isTyping=true;
        dialogText.text="";
        foreach(var letter in Lines.ToCharArray())
        {
            dialogText.text+=letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping=false;
    }
}
