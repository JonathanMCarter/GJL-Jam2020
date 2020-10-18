using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class Catapult : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip clips;

        public void CatShoot()
        {
            // base class method
            PlayClip(clips, .5f);
        }
    }
}