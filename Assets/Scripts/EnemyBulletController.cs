using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class EnemyBulletController : MonoBehaviour
    {
        private static Quaternion zero = Quaternion.identity;
        private Transform trans;
        private Rigidbody2D rb;

        public void Start()
        {
        }

        public void Awake()
        {

            trans = GetComponent<Transform>();
            rb = GetComponent<Rigidbody2D>();
        }


        public void SetInMotion(Vector3 pos)
        {
            ToggleActive(true);
            trans.position = pos;
            rb.AddForce(Vector2.left * GameConstants.ENEMY_BULLET_FORCE);
        }

        public bool IsActive() { return gameObject.activeInHierarchy; }


        public void ToggleActive(bool b)
        {
            gameObject.SetActive(b);
        }

        public void OnTriggerEnter2D(Collider2D hit)
        {
            if (hit.gameObject.CompareTag(GameConstants.BULLET_BORDER_TAG))
            {
                ToggleActive(false);
                return;
            }


        }
    }
}



