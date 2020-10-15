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
        private Animator anim;
        private int _id;
        private AsyncOperation async;
        private bool shouldLoad;
        private bool isCoR;


        private void OnDisable()
        {
            StopAllCoroutines();
        }


        private void Awake()
        {
            DontDestroyOnLoad(this);
            _id = FindObjectsOfType<SceneTransitions>().Length;

            if (FindObjectsOfType<SceneTransitions>().Length > 1)
            {
                for (int i = 0; i < FindObjectsOfType<SceneTransitions>().Length; i++)
                {
                    if (!FindObjectsOfType<SceneTransitions>()[i]._id.Equals(1))
                    {
                        Destroy(FindObjectsOfType<SceneTransitions>()[i], .05f);
                    }
                }
            }
        }

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();

            async = SceneManager.LoadSceneAsync("Main Level");
            async.allowSceneActivation = false;
        }


        private void Update()
        {
            if (async != null)
            {
                if (shouldLoad && !isCoR)
                {
                    StartCoroutine(TransitionCo());
                }
            }
        }

        public void ChangeSceneTransition(string sceneName)
        {
            StartCoroutine(ChangeSceneCo(sceneName));
        }


        private IEnumerator ChangeSceneCo(string sceneName)
        {
            anim.SetTrigger("ChangeScene");
            yield return new WaitForSeconds(.5f);
            shouldLoad = true;
        }


        private IEnumerator TransitionCo()
        {
            isCoR = true;
            async.allowSceneActivation = true;
            yield return new WaitForSeconds(.25f);
            anim.SetTrigger("FadeIn");
            isCoR = false;
            yield return new WaitForSeconds(.5f);
            shouldLoad = false;
        }
    }
}