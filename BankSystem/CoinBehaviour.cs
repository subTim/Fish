using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


    public class CoinBehaviour: MonoBehaviour 
    {
 
        private float speed;
        void Awake()
        {
            speed = GameManager.Singleton.speed;
           GameManager.OnChangeSpeed.AddListener( SpeedChange);
        }

        private void SpeedChange()
        {
            speed = GameManager.Singleton.speed;
        }

        public void Rotation()
        {
        Quaternion rotation= Quaternion.AngleAxis(0.1f, Vector3.up);
        transform.rotation *= rotation;
        }

        private void Update()
        {
            Rotation();

            transform.position -= new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }
