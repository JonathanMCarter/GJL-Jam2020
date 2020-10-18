using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class EnemyHit : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayEmHit()
        {
            // base class method
            PlayRandomFromGroup(clips, .15f);
        }
    }
}