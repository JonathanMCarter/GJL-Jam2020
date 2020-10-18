using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class GnomeMeleeAttacks : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayMeleeSound()
        {
            PlayRandomFromGroup(clips, .6f);
        }
    }
}