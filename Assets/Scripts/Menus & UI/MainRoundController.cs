using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoundController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> roundControllerObjects;
    public List<GameObject> completedRounds;
    

    void Start()
    {
        startRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void startRound()
    {
        Debug.Log("Starting the Round");
    }
}
