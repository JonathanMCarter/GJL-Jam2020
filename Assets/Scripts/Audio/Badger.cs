using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class Badger : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip clips;

        public void PlayBearRoar()
        {
            // base class method
            PlayClip(clips, .15f);
        }
    }
}