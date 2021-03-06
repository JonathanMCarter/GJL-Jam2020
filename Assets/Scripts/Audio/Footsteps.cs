﻿using UnityEngine;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes.Audio
{
    public class Footsteps : PlayAudioFromGroup
    {
        [SerializeField] private AudioClip[] clips;

        public void PlayFootstep()
        {
            // base class method
            PlayRandomFromGroup(clips, .6f);
        }
    }
}