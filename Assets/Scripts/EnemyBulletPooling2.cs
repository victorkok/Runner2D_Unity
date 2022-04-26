using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class EnemyBulletPooling2 : MonoBehaviour
    {

        public GameObject bulletPrefab2;
        public Transform bulletsContainer2;
        private int currentBulletIndex2;
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
                var go = Instantiate(bulletPrefab2);
                go.SetActive(false);
                go.transform.parent = bulletsContainer2;
                bullets.Add(go.GetComponent<EnemyBulletController>());
            }
        }

        public EnemyBulletController GetBullet()
        {
            EnemyBulletController b = bullets[currentBulletIndex2];
            if (b.IsActive())
            {
                print("Number of ENEMY4 Bullets not enough");
                return null;
            }

            currentBulletIndex2 = (currentBulletIndex2 + 1) % bullets.Count;
            return b;
        }
        #endregion
    }
}
