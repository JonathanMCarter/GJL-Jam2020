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

        private GnomeTrapControl traps;
        private Text _text;

        public enum Ellys { CableTrapAmount, BBQTrapAmount };
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
                default:
                    break;
            }
        }
    }
}