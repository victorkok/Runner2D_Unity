using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Runner
{

    public class Enemy2Shot : MonoBehaviour
    {
        public Animator Enemy2ShotSprite;
        private Transform trans;
        private float timer;
        private bool pause;
        private bool noChao;
        public Transform Muzzle;
        public EnemyBulletPooling bulletPool;

        // Use this for initialization
        
            public void Awake()
            {

                noChao = false;
                trans = GetComponent<Transform>();
                timer = GameConstants.ENEMY_SHOOT_INTERVAl - 1;
                pause = false;
            }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(GameConstants.PLATFORM_TAG))
            {
                noChao = true;
                Enemy2ShotSprite.Play("Atirando");
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(GameConstants.PLAYER_TAG))
            {

            }

            noChao = false;
        }
        // Update is called once per frame
        void Update()
        {
            if (pause) return;

            timer += Time.deltaTime;
			if (timer >= GameConstants.ENEMY_SHOOT_INTERVAl)
            {
                timer = 0;

                var Bullet = bulletPool.GetBullet();
                Bullet.SetInMotion(Muzzle.position);
                }
            }

        }
    }
