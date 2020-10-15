using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class SceneTransitions : MonoBehaviour
    {
        [SerializeField] private bool shouldAnimIntro = true;

        private Animator anim;
        private AsyncOperation async;


        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();

            if (shouldAnimIntro)
            {
                anim.SetTrigger("FadeIn");
            }

            async = new AsyncOperation();
        }


        public void ChangeSceneTransition(string sceneName)
        {
            StartCoroutine(ChangeSceneCo(sceneName));
        }


        private IEnumerator ChangeSceneCo(string sceneName)
        {
            anim.SetTrigger("ChangeScene");
            async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;
            yield return new WaitForSeconds(.55f);
            async.allowSceneActivation = true;
        }
    }
}