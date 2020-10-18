using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class GnomeLaugh : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayLaughSound()
        {
            PlayRandomFromGroup(clips);
        }
    }
}