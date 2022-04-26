using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class DoubleJump : MonoBehaviour
    {
        public GameObject[] PowerupDoubleJump;
        private Rigidbody2D rb;
        private float initialXPosition;
        public float minTopY;
        public float maxTopY;
        private bool pause;

        // Use this for initialization
        public void Awake()
        {

            rb = GetComponent<Rigidbody2D>();
            for (int i = 0; i < PowerupDoubleJump.Length; i++)
            {
                initialXPosition = PowerupDoubleJump[i].transform.position.x+5;
                PowerupDoubleJump[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
            }


        }

        void Update()
        {

            if (pause) return;
            for (int i = 0; i < PowerupDoubleJump.Length; i++)
            {
                PowerupDoubleJump[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
                //if (!platform[i].GetComponent<Renderer>().isVisible && platform[i].transform.position.x < 0)
                if (PowerupDoubleJump[i].transform.position.x + PowerupDoubleJump[i].transform.localScale.x < -17)

                    ResetPosition(PowerupDoubleJump[i].transform);





            }

        }



        private void ResetPosition(Transform t)
        {

            float y = UnityEngine.Random.Range(minTopY, maxTopY);
            float x = initialXPosition;
            t.position = new Vector3(x, y, 0);
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            for (int i = 0; i < PowerupDoubleJump.Length; i++)
                if (other.gameObject.CompareTag(GameConstants.PLAYER_TAG))
            {
                    ResetPosition(PowerupDoubleJump[i].transform);
            }
            
        }

    }

}