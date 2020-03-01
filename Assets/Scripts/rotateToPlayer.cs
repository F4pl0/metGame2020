using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateToPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(player.transform);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GameController.AddScore(50);
            GameController.AddEnergy(5);

            Destroy(gameObject);
        }
    }
}
