using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
public class Enemy3 : MonoBehaviour {

		private bool noChao = false;
        public Rigidbody2D rb;
        public float jumpSpeed = 4;


	// Use this for initialization
	
	        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
	
	void Start () {
		StartCoroutine(JumpLogic());
		
	}
	
	 IEnumerator JumpLogic()
 {
     float minWaitTime = 2;
     float maxWaitTime = 4;
 
     while (true)
     {
		yield return new WaitForSeconds(UnityEngine.Random.Range(minWaitTime, maxWaitTime));
         Jump();
     }
 }
	
	
	        public void Jump()

        {
            if (noChao == true)
            {
                rb.velocity += jumpSpeed * Vector2.up;
                
            }

            noChao = false;


        }

		void OnTriggerEnter2D(Collider2D other)
		{

		if (other.gameObject.CompareTag(GameConstants.PLATFORM_TAG))
		{
			noChao = true;
		}

		}
	
	
	        void OnTriggerExit2D(Collider2D other)
        {
		
            if (other.gameObject.CompareTag(GameConstants.PLAYER_TAG))
            {
                Die();

            }
        }

        void Die()
        {
            SceneManager.LoadScene(0);
        }
	
	// Update is called once per frame
	void Update () {
		
	}
 }
}
