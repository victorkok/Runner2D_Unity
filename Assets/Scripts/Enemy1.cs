using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Runner
{
    public class Enemy1 : MonoBehaviour
    {


        // Use this for initialization
        void Start()
        {

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
        void Update()
        {

        }
    }
}
