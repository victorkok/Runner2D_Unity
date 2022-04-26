using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner
{
	public class Enemy4 : MonoBehaviour {

        public Animator Enemy4ShotSprite;
        private bool noChao = false;
        private Transform trans;
        private float timer;
        private bool pause;
        public Rigidbody2D rb;
		public float jumpSpeed = 6;
        public Transform Muzzle2;
        public EnemyBulletPooling2 bulletPool2;


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
			float minWaitTime = 1;
			float maxWaitTime = 3;

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
                Enemy4ShotSprite.Play("Atirando2");

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
		void Update () {

            if (pause) return;

            timer += Time.deltaTime;
            if (timer >= GameConstants.ENEMY_SHOOT_INTERVAl)
            {
                timer = 0;

                var Bullet = bulletPool2.GetBullet();
                Bullet.SetInMotion(Muzzle2.position);
            }


        }
	}
}
