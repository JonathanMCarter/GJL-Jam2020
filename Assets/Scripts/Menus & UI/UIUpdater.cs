using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class UIUpdater : MonoBehaviour
    {
        // not an ideal solution to UI but it works...

        private FireworkMove firework;
        private GnomeTrapControl traps;
        private Text _text;

        public enum Ellys { CableTrapAmount, BBQTrapAmount, Fireworks };
        public Ellys element;



        private void Start()
        {
            _text = GetComponent<Text>();

            switch (element)
            {
                case Ellys.CableTrapAmount:

                    traps = GameObject.FindGameObjectWithTag("Player").GetComponent<GnomeTrapControl>();

                    break;
                case Ellys.BBQTrapAmount:

                    traps = GameObject.FindGameObjectWithTag("Player").GetComponent<GnomeTrapControl>();

                    break;
                case Ellys.Fireworks:

                    firework = GameObject.FindGameObjectWithTag("Player").GetComponent<FireworkMove>();

                    break;
                default:
                    break;
            }
        }


        private void Update()
        {
            switch (element)
            {
                case Ellys.CableTrapAmount:

                    if (!_text.text.Equals(traps.cableTraps.ToString()))
                    {
                        _text.text = traps.cableTraps.ToString();
                    }

                    break;
                case Ellys.BBQTrapAmount:

                    if (!_text.text.Equals(traps.bbqTrays.ToString()))
                    {
                        _text.text = traps.bbqTrays.ToString();
                    }

                    break;
                case Ellys.Fireworks:

                    if (!_text.text.Equals(firework.ammo.ToString()))
                    {
                        _text.text = firework.ammo.ToString();
                    }

                    break;
                default:
                    break;
            }
        }
    }
}