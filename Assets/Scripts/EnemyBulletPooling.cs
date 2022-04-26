using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{ 
public class EnemyBulletPooling : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletsContainer;
    private int currentBulletIndex;
    private List<EnemyBulletController> bullets;

    public void Start()
    {
        bullets = new List<EnemyBulletController>();
        bullets.Capacity = GameConstants.ENEMY_BULLET_NUMBER;
        AddBulletsToThePool();
    }

    #region Regular Bullets
    private void AddBulletsToThePool()
    {
        for (int i = 0; i < GameConstants.ENEMY_BULLET_NUMBER; i++)
        {
            var go = Instantiate(bulletPrefab);
            go.SetActive(false);
            go.transform.parent = bulletsContainer;
            bullets.Add(go.GetComponent<EnemyBulletController>());
        }
    }

    public EnemyBulletController GetBullet()
    {
        EnemyBulletController b = bullets[currentBulletIndex];
        if (b.IsActive())
        {
            print("Number of ENEMY Bullets not enough");
            return null;
        }

        currentBulletIndex = (currentBulletIndex + 1) % bullets.Count;
        return b;
    }
    #endregion
}
}