using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class Footsteps : MonoBehaviour
    {
        [SerializeField] private AudioClip[] footsteps;
        [SerializeField] private GameObject soundPrefab;

        public void PlayFootstep()
        {
            GameObject clip = Instantiate(soundPrefab);
            clip.GetComponent<AudioSource>().clip = footsteps[Random.Range(0,7)];
            clip.GetComponent<AudioSource>().volume = Random.Range(.8f, 1f);
            clip.GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
            clip.GetComponent<AudioSource>().Play();
            Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
        }
    }
}