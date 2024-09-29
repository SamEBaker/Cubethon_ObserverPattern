using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chapter.Observer
{
    public class EndTrigger : MonoBehaviour
    {
        public GameManager gameManager;
        void OnTriggerEnter ()
        {
            gameManager.CompleteLevel();
            Debug.Log("Level Complete");
        }
    }


}
