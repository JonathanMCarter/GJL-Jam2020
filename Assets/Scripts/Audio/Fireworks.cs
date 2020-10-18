using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class Fireworks : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayFireworkShoot()
        {
            // base class method
            PlayClip(clips[0], .4f);
        }

        public void PlayFireworkHit()
        {
            // base class method
            PlayClip(clips[1]);
        }
    }
}