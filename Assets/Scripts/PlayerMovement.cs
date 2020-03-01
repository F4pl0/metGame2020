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

    private float prevHMov = 0f,
                  prevVMov = 0f;
    private float transTime = 0f;


    Rigidbody rb;
    public float speed;

    private float rot = 0f;

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
        if (!GameController.playing) {
            return;
        }
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
                Input.GetAxis("Vertical") <= prevV) {
                mV = -1f;
                break;
            }

            if (Input.GetAxis("Vertical") < 0 &&
                Input.GetAxis("Vertical") > prevV) {
                break;
            }

            if (Input.GetAxis("Vertical") > 0 &&
                Input.GetAxis("Vertical") >= prevV) {
                mV = 1f;
                break;
            }

            if (Input.GetAxis("Vertical") > 0 &&
                Input.GetAxis("Vertical") < prevV) {
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


        if (prevHMov != 0 && prevHMov == mH) {
            transTime += Time.deltaTime;
        } else {
            transTime = 0f;
        }

        if(transTime > 1f) {
            gameObject.transform.Rotate(0, mH > 0 ? 90 : -90, 0);
            rot += mH > 0 ? 90f : -90f;
            if (rot == 360f) {
                rot = 0;
            }
            if (rot == -90f) {
                rot = 270f;
            }
            transTime = .35f;
        }

        prevHMov = mH;
        prevVMov = mV;

        rb.angularVelocity = new Vector3();

        if(rot == 90f) {
            float temp = mH;
            mH = mV;
            mV = -temp;
        } else if (rot == 180f) {
            mH = -mH;
            mV = -mV;
        } else if (rot == 270f) {
            float temp = mV;
            mV = mH;
            mH = -temp;
        }

        rb.velocity = new Vector3(mH * speed, rb.velocity.y, mV * speed);
    }
}
