using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public GameObject attackCollider;
    public GameObject slash;

    int a = 0;

    private bool cool = false;
    

    // Start is called before the first frame update
    void Start()
    {
        attackCollider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(a == 5) {
            slash.SetActive(false);
            a = 0;
        }
        if (slash.active) {
            a++;
        }
        if (attackCollider.active) {
            attackCollider.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space)) {
            if (!cool) {
                cool = true;
                attackCollider.SetActive(true);
                slash.SetActive(true);
                slash.transform.Rotate(0, 0, Random.Range(0, 360));
            }
        } else {
            cool = false;
        }
    }
}
