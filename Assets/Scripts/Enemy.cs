using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public GameObject pickup;
    public GameObject pickupa;
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
        if (other.gameObject.tag == "knife") {
            GameController.AddScore(100);

            GameObject.Instantiate(pickup,
                player.transform.position + (player.transform.forward*2), Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
