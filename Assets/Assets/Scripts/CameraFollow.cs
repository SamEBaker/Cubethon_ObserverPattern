using UnityEngine;


namespace Chapter.Observer
{
    public class CameraFollow : MonoBehaviour
    {
        // Start is called before the first frame update
        public Transform player;
        public Vector3 offset;

        // Update is called once per frame
        void Update()
        {
            transform.position = player.position + offset;
        }
    }
}

