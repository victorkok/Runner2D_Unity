using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
namespace Runner
{
    public class TapController : MonoBehaviour
    {


        public PlayerController playerController;
        private TapGesture tapGesture;
        // Use this for initialization
        public void Start()
        {

            tapGesture = GetComponent<TapGesture>();
            tapGesture.Tapped += TapHandler;

        }

        public void TapHandler(object sender, System.EventArgs e)
        {
            playerController.Jump();
        }

    }

}