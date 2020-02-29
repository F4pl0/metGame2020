using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    private Animator anim;
    private SpriteRenderer playerSR;
    public GameObject spriteObj;

    public Sprite sForward;
    public Sprite sBack;
    public Sprite sLeft;
    public Sprite sRight;


    Rigidbody rb;
    public float speed;

    private float prevH = 0f;
    private float prevV = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = spriteObj.GetComponent<Animator>();
        playerSR = spriteObj.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float mH = 0f;
        while (true) {
            if (Input.GetAxis("Horizontal") == 0) {
                break;
            }

            if (Input.GetAxis("Horizontal") < 0 &&
                Input.GetAxis("Horizontal") <= prevH) {
                mH = -1f;
                break;
            }

            if (Input.GetAxis("Horizontal") < 0 &&
                Input.GetAxis("Horizontal") > prevH) {
                break;
            }

            if (Input.GetAxis("Horizontal") > 0 &&
                Input.GetAxis("Horizontal") >= prevH) {
                mH = 1f;
                break;
            }

            if (Input.GetAxis("Horizontal") > 0 &&-
                Input.GetAxis("Horizontal") < prevH) {
                break;
            }

            break;
        }

        float mV = 0f;
        while (true) {
            if (Input.GetAxis("Vertical") == 0) {
                break;
            }

            if (Input.GetAxis("Vertical") < 0 &&
                Input.GetAxis("Vertical") <= prevH) {
                mV = -1f;
                break;
            }

            if (Input.GetAxis("Vertical") < 0 &&
                Input.GetAxis("Vertical") > prevH) {
                break;
            }

            if (Input.GetAxis("Vertical") > 0 &&
                Input.GetAxis("Vertical") >= prevH) {
                mV = 1f;
                break;
            }

            if (Input.GetAxis("Vertical") > 0 &&
                Input.GetAxis("Vertical") < prevH) {
                break;
            }

            break;
        }
        prevH = Input.GetAxis("Horizontal");
        prevV = Input.GetAxis("Vertical");

        anim.SetBool("mV", mV != 0f);
        anim.SetBool("mH", mH != 0f);

        if (mV == 0f && mH == 1f) {
            playerSR.sprite = sRight;
        } else if (mV == 0f && mH == -1f) {
            playerSR.sprite = sLeft;
        } else if (mV == 1f && mH == 0f) {
            playerSR.sprite = sForward;
        } else if (mV == -1f && mH == 0f) {
            playerSR.sprite = sBack;
        }

        rb.velocity = new Vector3(mH * speed, rb.velocity.y, mV * speed);
    }
}
