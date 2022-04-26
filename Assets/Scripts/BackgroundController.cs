using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Runner
{
    public class BackgroundController : MonoBehaviour
    {

        private Transform[] bgs;
        private Vector3[] originalPos;
        private bool pause;
        private Vector3 resetPosition;

        public void Awake()
        {
            pause = false;
            var g = GetComponentsInChildren<Transform>();
            bgs = new Transform[g.Length - 1];
            originalPos = new Vector3[g.Length - 1];
            for (int i = 1; i < g.Length; i++)
            {
                bgs[i - 1] = g[i];
                originalPos[i - 1] = g[i].position;
            }

            resetPosition = originalPos[g.Length - 2];
        }

        void Update()
        {
            if (pause) return;

            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i].Translate(-4F * Time.deltaTime, 0, 0);
                if (bgs[i].position.x < -17)
                    bgs[i].position = resetPosition;
            }
        }
    }
}