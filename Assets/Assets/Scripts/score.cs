using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Chapter.Observer
{
    public class score : Subject
    {
        public Transform player;
        public Text scoreText;
        public TMP_Text message;
        public bool ScoreReached;
        private CamObserver cF;
        public Camera cam;
        public bool Flipped;
        public bool TargetReached;

        void Awake()
        {
            cF = gameObject.AddComponent<CamObserver>();
        }
        // Update is called once per frame
        void OnEnable()
        {
            if (cF)
                Attach(cF);
        }

        void OnDisable()
        {
            if (cF)
                Detach(cF);
        }
        void Update()
        {
            scoreText.text = player.position.z.ToString("0");
            if(player.position.z >= 300)
            {
                Debug.Log("AHHHHHH");
                ScoreReached = true;
                NotifyObservers();
            }
            else if(player.position.z >= 200)
            {
                TargetReached = true;
                NotifyObservers();
            }
        }
        public void FlipCamera()
        {
            if (ScoreReached && !Flipped)
            {
                cam.transform.Rotate(0, 0, 180);
                Flipped = true;
                ScoreReached = false;
            }
        }

    }


}

