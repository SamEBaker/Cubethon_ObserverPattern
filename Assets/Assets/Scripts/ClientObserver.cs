using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private playerMovement pM;
        void Start()
        {
            pM = (playerMovement)FindObjectOfType(typeof(playerMovement));
        }
        
        //add checks


        
        void OnGUI()
        {
            if (GUILayout.Button("EASY MODE"))
                if (pM)
                    pM.ToggleEasy();
        }
    }
}