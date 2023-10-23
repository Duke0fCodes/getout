using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int lettersPerSecond;
    public static DialogueManager Instance{get; private set;}
    private void Awake()
    {
        Instance=this;
    }
    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }
    public IEnumerator TypeDialog(string Lines)
    {
        dialogText.text="";
        foreach(var letter in Lines.ToCharArray())
        {
            dialogText.text+=letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
}
