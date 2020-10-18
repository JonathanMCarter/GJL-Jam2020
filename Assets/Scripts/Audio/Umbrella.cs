using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class Umbrella : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip clips;

        public void PlayUm()
        {
            // base class method
            PlayClip(clips, .5f);
        }
    }
}