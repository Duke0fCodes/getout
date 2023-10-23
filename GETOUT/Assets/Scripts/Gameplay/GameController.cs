using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState {FreeRoam, Dialog}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController; 
    [SerializeField] Camera camera;
    static GameState state;

    // Update is called once per frame
    private void Start()
    {
        DialogueManager.Instance.OnShowDialog+=()=>
        {
            state=GameState.Dialog;
        };
        DialogueManager.Instance.OnCloseDialog+=()=>
        {
            if(state == GameState.Dialog)
            state=GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if(state == GameState.FreeRoam)
        {
            
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialog)
        {
            DialogueManager.Instance.HandleUpdate();
        }
    }
}
