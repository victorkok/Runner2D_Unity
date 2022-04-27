using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Runner
{
    public class PlayerController : MonoBehaviour
    {
        public Animator PlayerSprite;
        public Rigidbody2D rb;
        private bool noChao = false;
        public float jumpSpeed = 10;
        private float powerupLenght;
        private bool candoublejump;
        private bool powerupActive;
        private float powerupLengthCounter;
        public PauseMenu pauseMenu;
        void Awake()
        {
            PlayerSprite = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        public void Jump()

        {

            if (noChao == true)
            {
                rb.velocity += jumpSpeed * Vector2.up;
                PlayerSprite.Play("Jump", 0, 0);
            }
            else
            {
                if (candoublejump && noChao == false)
                {
                    candoublejump = false;
                    rb.velocity = new Vector2(0, 0);

                    rb.velocity += jumpSpeed/1F * Vector2.up;

                }
                
            }
            noChao = false;


        }

        void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.CompareTag(GameConstants.POWER_UP_DOUBLEJUMP))
            {
                candoublejump = true;
            }
            


            if (other.gameObject.CompareTag(GameConstants.PLATFORM_TAG))
            {
                noChao = true;
                PlayerSprite.Play("Running");
            }

            if (other.gameObject.CompareTag(GameConstants.ENEMY_TAG))
            {
                {
                    Die();
                }
            }

            if (other.gameObject.CompareTag(GameConstants.ENEMY_BULLET))
            {
                {
                    Die();
                }
            }

        }

        void Die()
        {
            SceneManager.LoadScene(0);
        }

    }
}