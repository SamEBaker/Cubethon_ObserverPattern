
using System.Collections.Generic;
using UnityEngine;


namespace Chapter.Observer
{
    public class playerMovement : Subject
    {
        // Start is called before the first frame update
        public Rigidbody rb;
        public bool EasyMode;
        GameManager manager;
        private GameManager gm;
        public float forwardForce = 2000;
        public float sidewaysForce = 500f;
        public GameObject Obstacles;

        void Awake()
        {
            gm = gameObject.AddComponent<GameManager>();
        }
        public void Start()
        {
            manager = FindObjectOfType<GameManager>();
        }
        void OnEnable()
        {
            if (gm)
                Attach(gm);
        }
        void OnDisable()
        {
            if (gm)
                Detach(gm);
        }

        void FixedUpdate()
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            if( Input.GetKey("d"))
            {
                //rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                Command moveRight = new MoveRight(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.Command(moveRight);
                invoker.ExecuteCommand();

            }

            if( Input.GetKey("a"))
            {
                //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                Command moveLeft = new MoveLeft(rb, sidewaysForce);
                Invoker invoker = new Invoker();
                invoker.Command(moveLeft);
                invoker.ExecuteCommand();
            }

            if(rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame(null);
            }
        }
        public void ToggleEasy()
        {
            EasyMode = !EasyMode;
            NotifyObservers();
        }
        void Update()
        {
            if (EasyMode)
            {
                Obstacles.SetActive(false);
            }
            else
            {
                Obstacles.SetActive(true);
            }
        }
    }
}

