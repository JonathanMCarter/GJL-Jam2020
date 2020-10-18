using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class SunHit : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlaySunHit()
        {
            PlayRandomFromGroup(clips);
        }
    }
}