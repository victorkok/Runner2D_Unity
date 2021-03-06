using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class Powerup : MonoBehaviour
    {
        public GameObject[] DoubleJump;
        private Rigidbody2D rb;
        private float initialXPosition;
        public float minTopY;
        public float maxTopY;
        private bool pause;

        // Use this for initialization
        public void Awake()
        {

            rb = GetComponent<Rigidbody2D>();
            for (int i = 0; i < DoubleJump.Length; i++)
            {
                initialXPosition = DoubleJump[i].transform.position.x - 6;
                DoubleJump[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
            }


        }

        void Update()
        {

            if (pause) return;
            for (int i = 0; i < DoubleJump.Length; i++)
            {
                DoubleJump[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
                //if (!platform[i].GetComponent<Renderer>().isVisible && platform[i].transform.position.x < 0)
                if (DoubleJump[i].transform.position.x + DoubleJump[i].transform.localScale.x < -17)

                    ResetPosition(DoubleJump[i].transform);
                   




            }

        }



        private void ResetPosition(Transform t)
        {

            float y = UnityEngine.Random.Range(minTopY, maxTopY);
            float x = initialXPosition;
            t.position = new Vector3(x, y, 0);
        }


    }

}

