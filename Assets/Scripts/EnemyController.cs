using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
    public GameObject []Enemy1;
    private Rigidbody2D rb;
    private float initialXEnemyPosition;
    public float minTopY;
    public float maxTopY;
    private bool pause;

    // Use this for initialization
    public void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Enemy1.Length; i++)
        {
            initialXEnemyPosition = Enemy1[i].transform.position.x - 6;
            Enemy1[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
        }


    }

    void Update()
    {

        if (pause) return;
        for (int i = 0; i < Enemy1.Length; i++)
        {
            Enemy1[i].transform.Translate(-4F * Time.deltaTime, 0, 0);
            //if (!platform[i].GetComponent<Renderer>().isVisible && platform[i].transform.position.x < 0)
            if (Enemy1[i].transform.position.x + Enemy1[i].transform.localScale.x < -17)

                ResetPosition(Enemy1[i].transform);
            if (Enemy1[i].transform.position.y < -10)
                ResetPosition(Enemy1[i].transform);


        }


    }



    private void ResetPosition(Transform t)
    {

        float y = UnityEngine.Random.Range(minTopY, maxTopY);
        float x = initialXEnemyPosition;

        t.position = new Vector3(x, y, 0);
        // Update is called once per frame
    }

}
