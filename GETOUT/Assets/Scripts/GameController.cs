using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState {FreeRoam}
public class GameController : MonoBehaviour
{
   GameState state;

    // Update is called once per frame
    private void Update()
    {
        if(state == GameState.FreeRoam)
        {

        }
    }
}
