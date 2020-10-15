using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class MenuButtons : MonoBehaviour
    {
        private SceneTransitions sceneTrans;


        private void Start()
        {
            sceneTrans = GameObject.FindGameObjectWithTag("SceneTransition").GetComponent<SceneTransitions>();
        }

        /// <summary>
        /// Changes scene to the main menu with a transition
        /// </summary>
        public void ToMenu()
        {
            sceneTrans.ChangeSceneTransition("Main Menu");
        }

        /// <summary>
        /// Changes scene to the main level with a transition
        /// </summary>
        public void ToLevel()
        {
            sceneTrans.ChangeSceneTransition("Main Level");
        }
    }
}