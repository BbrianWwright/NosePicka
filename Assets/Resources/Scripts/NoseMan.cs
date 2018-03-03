using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseMan : MonoBehaviour
{

    private bool happy_ = false;

    public GameObject left_eye_;
    public GameObject right_eye_;
    public GameObject eww_emitter_;
    public GameObject word_emitter_;

    private Animator animator_;
    private Sprite eye_happy_;
    private Sprite eye_sad_;

    private float booger_interval_counter_ = 0;
    public float booger_interval_;

    private float word_interval_counter_ = 0;
    public float word_interval_;

    // Use this for initialization
    void Start()
    {
        animator_ = left_eye_.GetComponent<Animator>();
        //animator_.Stop();
        eye_happy_ = Resources.Load <Sprite> ("Sprites/eye_happy");
        eye_sad_ = Resources.Load <Sprite> ("Sprites/eye_open");
        
        SpriteRenderer sp = left_eye_.GetComponent<SpriteRenderer>();
        sp.sprite = eye_sad_;

        sp = right_eye_.GetComponent<SpriteRenderer>();
        sp.sprite = eye_sad_;

    }

    // Update is called once per frame
    void Update()
    {
        if (happy_)
        {

            SpriteRenderer sp = left_eye_.GetComponent<SpriteRenderer>();
            sp.sprite = eye_happy_;

            sp = right_eye_.GetComponent<SpriteRenderer>();
            sp.sprite = eye_happy_;
               
            //Debug.Log("happy eyes");
            //animator_.Stop();
            // set sprite animation to eyes closed
            animator_.Play("eye_happy_animation");
            //animator_.StartPlayback();
            //animator_.se

            // set mouth to move

            booger_interval_counter_ -= Time.deltaTime;

            if (booger_interval_counter_ < 0)
            {
                float booger_chance = Random.Range(0.0f, 5.0f);
                Debug.Log(booger_chance);
                if (booger_chance < 3.0f)
                {
                    GameObject booger = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/booger_" + Random.Range(0, 3).ToString()));
                    booger.transform.position = new Vector3(eww_emitter_.transform.position.x, eww_emitter_.transform.position.y, eww_emitter_.transform.position.z);
                }
                else if (booger_chance > 4.0f)
                {
                    GameObject booger = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/booger_money"));
                    booger.transform.position = new Vector3(eww_emitter_.transform.position.x, eww_emitter_.transform.position.y, eww_emitter_.transform.position.z);
                }

                // reset
                booger_interval_counter_ = booger_interval_;
            }


            word_interval_counter_ -= Time.deltaTime;

            if (word_interval_counter_ < 0)
            {
                float word_chance = Random.Range(0.0f, 5.0f);
                if (word_chance < 3.0f)
                {
                    GameObject word = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/word_" + Random.Range(0, 3).ToString()));
                    word.transform.position = new Vector3(word_emitter_.transform.position.x + 3.0f, word_emitter_.transform.position.y, word_emitter_.transform.position.z);
                    word.transform.rotation = new Quaternion(word.transform.rotation.x, word.transform.rotation.y, word.transform.rotation.z + Random.Range(-0.5f,0.5f), word.transform.rotation.w);

                    word = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/word_" + Random.Range(0, 3).ToString()));
                    word.transform.position = new Vector3(word_emitter_.transform.position.x -3.5f, word_emitter_.transform.position.y + 0.5f, word_emitter_.transform.position.z);
                    word.transform.rotation = new Quaternion(word.transform.rotation.x, word.transform.rotation.y, word.transform.rotation.z + Random.Range(-0.5f,0.5f), word.transform.rotation.w);
                }
                // reset
                word_interval_counter_ = word_interval_;
            }


        }
        else
        {
            //Debug.Log("sad eyes");
            animator_.Stop();

            SpriteRenderer sp = left_eye_.GetComponent<SpriteRenderer>();
            sp.sprite = eye_sad_;

            sp = right_eye_.GetComponent<SpriteRenderer>();
            sp.sprite = eye_sad_;
            // set normal eyes sprite

        }


    }

    public bool isHappy()
    {
        return happy_; // :)
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "finger")
        {
            happy_ = true;
            //audio

        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "finger")
        {
            happy_ = false;
            //audio

        }
    }

}
