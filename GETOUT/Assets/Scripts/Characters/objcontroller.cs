using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objcontroller : MonoBehaviour, Interactable
{
   public void Interact()
   {
<<<<<<< Updated upstream:GETOUT/Assets/Scripts/Player/objcontroller.cs
      Debug.Log("Interacting");
=======
      StartCoroutine(DialogueManager.Instance.ShowDialog(dialog));
>>>>>>> Stashed changes:GETOUT/Assets/Scripts/Characters/objcontroller.cs
   }
}
