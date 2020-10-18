using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class GnomeDeath : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayDeathSound()
        {
            PlayRandomFromGroup(clips, .3f);
        }
    }
}