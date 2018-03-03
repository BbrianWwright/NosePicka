using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMan : MonoBehaviour
{
    public GameObject left_eye_;
    public GameObject right_eye_;
    private float look_stay_counter_ = 0;

    private float look_speed_counter = 0;
    private float look_speed_time = 0;

    //ugh
    public List<float> look_times_ = new List<float>(new float[]{0.3f, 1.0f, 2.3f, 1.6f, 1.2f, 3.2f, 4.0f, 2.5f, 4.5f, 1.0f});
    //public float[] look_times_ = new float[3.0, 2.0, 2.3, 1.6, 1.2, 3.2, 4, 2.5, 4.5, 1.0];

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        look_stay_counter_ -= Time.deltaTime;

        if (look_stay_counter_ < 0)
        {
            // translate eyes to other side

            look_stay_counter_ = Random.Range(0.1f, 8.0f);
        }
            

		
	}

    public bool isAlert()
    {
        // are eyes facing left completely?
        return true;
    }
}
