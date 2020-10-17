using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class PlayAudioFromGroup : MonoBehaviour
    {
        [SerializeField] private GameObject soundPrefab;

        public void PlayRandomFromGroup(AudioClip[] clips)
        {
            GameObject clip = Instantiate(soundPrefab);
            clip.GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
            clip.GetComponent<AudioSource>().volume = Random.Range(.8f, 1f);
            clip.GetComponent<AudioSource>().pitch = Random.Range(.9f, 1.1f);
            clip.GetComponent<AudioSource>().Play();
            Destroy(clip, clip.GetComponent<AudioSource>().clip.length);
        }
    }
}