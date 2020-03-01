using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public GameObject attackCollider;

    private bool cool = false;
    

    // Start is called before the first frame update
    void Start()
    {
        attackCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCollider.active) {
            attackCollider.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space)) {
            if (!cool) {
                cool = true;
                attackCollider.SetActive(true);
            }
        } else {
            cool = false;
        }
    }
}
