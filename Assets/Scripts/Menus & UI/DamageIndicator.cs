using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*  Copyright (c) Jonathan Carter
*  E: jonathan@carter.games
*  W: https://jonathan.carter.games/
*/

namespace DresslikeaGnome.OhGnomes
{
    public class DamageIndicator : MonoBehaviour
    {
        [SerializeField] private int numberOfIndicators;
        [SerializeField] private GameObject indicatorPrefab;
        [SerializeField] private Transform cam;

        private List<GameObject> indicators;


        private void Start()
        {
            indicators = new List<GameObject>();

            for (int i = 0; i < numberOfIndicators; i++)
            {
                GameObject _go = Instantiate(indicatorPrefab, transform);
                _go.name = "* (UI Pool) - Damage Indicator *";
                _go.SetActive(false);
                indicators.Add(_go);
            }
        }


        public void ShowDMGIndicator(Vector3 _tPos, int dmg, Color _textColour)
        {
            for (int i = 0; i < indicators.Count; i++)
            {
                if (!indicators[i].activeInHierarchy)
                {
                    indicators[i].transform.position = _tPos;
                    indicators[i].transform.rotation = cam.transform.rotation;
                    indicators[i].GetComponent<Text>().text = dmg.ToString();
                    indicators[i].GetComponent<Text>().color = _textColour;
                    indicators[i].SetActive(true);
                    break;
                }
            }
        }
    }
}