using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chapter.Observer
{
    public class CamObserver : Observer

    {
        private score score;
        private bool TargetReached;
        private bool FirstReached;

        void Update()
        {
            if (TargetReached == true)
            {
                score.FlipCamera();
                score.message.text = "OH NO";
            }
            if (FirstReached == true)
            {
                score.message.text = "Uh oh...do you feel that?";
            }
        }
        public override void Notify(Subject subject)
        {
            Debug.Log("Override");
            if (!score)
            {
                score = subject.GetComponent<score>();
            }
            if (score)
            {
                TargetReached = score.ScoreReached;
                FirstReached = score.TargetReached;
            }

        }
    }

}
