using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class RatHit : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip clips;

        public void PlayRatHit()
        {
            // base class method
            PlayFromTime(clips, .75f, .6f);
        }
    }
}