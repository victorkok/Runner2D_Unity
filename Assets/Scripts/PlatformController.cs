using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{

    public class PlatformController : MonoBehaviour
    {

        public GameObject[] platform;
        private Rigidbody2D rb;
        private float initialXPosition;
        public float minTopY;
        public float maxTopY;
        private bool pause;


        public void Awake()
        {
            pause = false;
            rb = GetComponent<Rigidbody2D>();
            for (int i = 0; i < platform.Length; i++)
            {
                initialXPosition = platform[i].transform.position.x - 6;
                platform[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
            }
        }

        void Update()
        {

            if (pause) return;
            for (int i = 0; i < platform.Length; i++)
            {
                platform[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
                //if (!platform[i].GetComponent<Renderer>().isVisible && platform[i].transform.position.x < 0)
                if (platform[i].transform.position.x + platform[i].transform.localScale.x < -17)

                    ResetPosition(platform[i].transform);


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