using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScreenController : MonoBehaviour {
    public string PLAYER_TAG = "Player";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            Die();

        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
