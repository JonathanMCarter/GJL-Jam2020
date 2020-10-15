using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class MusicCrossfade : MonoBehaviour
    {
        private enum ActiveStage { L1, L2, L3 };
        private ActiveStage stage;
        private AudioSource[] tracks;
        private float transitionSpeed = 1f;


        private void Start()
        {
            tracks = GetComponents<AudioSource>();
        }


        private void Update()
        {
            switch (stage)
            {
                case ActiveStage.L1:

                    if (tracks[0].volume != 1)
                    {
                        tracks[0].volume += transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[1].volume != 0)
                    {
                        tracks[1].volume -= transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[2].volume != 0)
                    {
                        tracks[2].volume -= transitionSpeed * Time.deltaTime;
                    }

                    break;
                case ActiveStage.L2:

                    if (tracks[0].volume != 0)
                    {
                        tracks[0].volume -= transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[1].volume != 1)
                    {
                        tracks[1].volume += transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[2].volume != 0)
                    {
                        tracks[2].volume -= transitionSpeed * Time.deltaTime;
                    }

                    break;
                case ActiveStage.L3:

                    if (tracks[0].volume != 0)
                    {
                        tracks[0].volume -= transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[1].volume != 0)
                    {
                        tracks[1].volume -= transitionSpeed * Time.deltaTime;
                    }

                    if (tracks[2].volume != 1)
                    {
                        tracks[2].volume += transitionSpeed * Time.deltaTime;
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Increases the track intensity by 1
        /// </summary>
        public void IncreaseIntensity()
        {
            if (!stage.Equals(ActiveStage.L3))
            {
                stage += 1;
            }
        }

        /// <summary>
        /// Decreses the track intensity by 1
        /// </summary>
        public void DecreaseIntensity()
        {
            if (!stage.Equals(ActiveStage.L1))
            {
                stage -= 1;
            }
        }

        /// <summary>
        /// Set the transition speed to be faster, default is 1
        /// </summary>
        /// <param name="value">Float: value to change the speed to</param>
        public void SetTransitionSpeed(float value)
        {
            transitionSpeed = value;
        }
    }
}