using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class GnomeRangedAttack : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayRangedAttack()
        {
            PlayRandomFromGroup(clips);
        }
    }
}