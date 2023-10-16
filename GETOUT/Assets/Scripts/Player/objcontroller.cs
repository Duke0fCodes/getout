using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectcontroller : MonoBehaviour, Interactable
{
   [SerializeField]Dialog dialog;
   public void Interact()
   {
      DialogueManager.Instance.ShowDialog(dialog);
   }
}
