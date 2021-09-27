using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        HandleKeyInput();
    }

    private void HandleKeyInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quitting.");
            Application.Quit();
        }
    }
}
