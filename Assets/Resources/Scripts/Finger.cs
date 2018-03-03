using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    public float finger_speed_ = 10.0f;
    public float finger_upper_bound_y_;
    public float finger_lower_bound_y_;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
         {
             transform.position += Vector3.up * finger_speed_ * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * finger_speed_ * Time.deltaTime;
         }

        //float translation = Input.GetAxis("Vertical") * finger_speed_;
        //transform.Translate(0, translation, 0);

        // lock finger within bounds
        if (transform.position.y > finger_upper_bound_y_)
        {
            transform.position = new Vector3(transform.position.x, finger_upper_bound_y_, transform.position.z);
        }
        if (transform.position.y < finger_lower_bound_y_)
        {
            transform.position = new Vector3(transform.position.x, finger_lower_bound_y_, transform.position.z);
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");
        //if (collision.gameObject.tag == "NoseMan")
         //   collision.gameObject.SendMessage("ApplyDamage", 10);
        
    }

}
