using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class EnemyFootStep : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip clips;

        public void FS()
        {
            // base class method
            PlayClip(clips, .01f);
        }
    }
}