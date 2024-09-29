using UnityEngine;

namespace Chapter.Observer
{
	public class PlayerCollision : MonoBehaviour
	{
		public playerMovement movement;

		public delegate void HitObstacle(Collision collisionInfo);
		public static event HitObstacle OnHitObstacle;

		private void OnCollisionEnter (Collision collisionInfo)
		{
			if (collisionInfo.collider.tag == "Obstacles")
			{

				if(OnHitObstacle != null)
				{
					OnHitObstacle(collisionInfo);
				}

				movement.enabled = false;
				//FindObjectOfType<GameManager>().EndGame();
				Debug.Log("You Died");
			}
		}
	}

}


