using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAndFinishGame : MonoBehaviour
{
    public void StartGame()
    {
        CommandList.GameStart = true;
    }

    public void FinishtGame()
    {
        CommandList.GameStart = false;
    }
}
