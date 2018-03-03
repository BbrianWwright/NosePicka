using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {
    public NoseMan nose_man_;
    public PoliceMan police_man_;

    public bool game_active_ = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!game_active_)
        {
            // Press spacebar to restart

        }

        if (police_man_.isAlert() && nose_man_.isHappy())
        {
            // game over, you just got caught picking your nose
        
            // animate police man mouth
            
            // move gun

            // audio,

        }

        
		
	}
}
