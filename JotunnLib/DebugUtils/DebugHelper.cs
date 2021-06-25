﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jotunn.DebugUtils
{
    internal class DebugHelper : MonoBehaviour
    {

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F6))
            { // Set a breakpoint here to break on F6 key press
            }
        }

        private void OnGUI()
        {
            // Display version in main menu
            if (SceneManager.GetActiveScene().name == "start")
            {
                GUI.Label(new Rect(Screen.width - 100, 5, 100, 25), "Jötunn v" + Main.Version);
            }
        }

    }
}
