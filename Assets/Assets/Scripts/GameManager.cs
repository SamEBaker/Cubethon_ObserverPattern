using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;


namespace Chapter.Observer
{
	public class GameManager : Observer
	{
		bool gameHasEnded = false;
		//public float restartDelay = 1f;
		private playerMovement pM;
        bool instantReplay = false;
		public GameObject player;
		private float replayStartTime;
		public GameObject completeLevelUI;
		private ColorGrading colorGrading;
		public PostProcessVolume volume;
		private int Deaths;
		public bool EasyMode;
	

		private void OnEnable()
		{
			PlayerCollision.OnHitObstacle += EndGame;
		}

		private void OnDisable()
		{
			PlayerCollision.OnHitObstacle -= EndGame;
		}

        private void Start()
		{
			//volume.profile.TryGetSettings(out colorGrading);
			//colorGrading.saturation.value = 0f;
            playerMovement playermovement = FindObjectOfType<playerMovement>();
            player = playermovement.gameObject;

			if(CommandLog.commands.Count > 0)
			{
				instantReplay = true;
				replayStartTime = Time.timeSinceLevelLoad;
			}
		}
        void Update()
        {

        }
        void FixedUpdate()
		{
		   if(instantReplay )
			{

				RunInstantReplay();
			}

		}
		public void CompleteLevel ()
		{
			completeLevelUI.SetActive(true);
		}

        public void EndGame (Collision collisionInfo)
		{
			player.GetComponent<playerMovement>().enabled = false;
			PlayerCollision.OnHitObstacle -= EndGame;


			if(collisionInfo != null)
			{
				Debug.Log("hit");
			}

			if (!gameHasEnded)
			{
				gameHasEnded = true;
				Invoke("Restart", 2f);
			}

			if(gameHasEnded == false)
			{
				gameHasEnded = true;
				Invoke("Restart", 2f);
				Debug.Log("Restart");
			}
		}

		void Restart()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
        public override void Notify(Subject subject)
        {
			if (!pM)
			{
				pM = subject.GetComponent<playerMovement>();
			}
			if (pM)
			{
				EasyMode = pM.EasyMode;
			}

        }

        void RunInstantReplay()
		{

			//colorGrading.saturation.value = -100f;
			if (CommandLog.commands.Count == 0)
			{
				return;
			}
			Command command = CommandLog.commands.Peek();
			if(Time.timeSinceLevelLoad >= command.timeStamp)
			{
				command = CommandLog.commands.Dequeue();
				command.rb = player.GetComponent<Rigidbody>();
				Invoker invoker = new Invoker();
				Debug.Log("Replay Mode");


				invoker.disableLog = true;
				invoker.Command(command);
				invoker.ExecuteCommand();
			}
		}
	}
}

