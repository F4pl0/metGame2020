using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float speed = 6.5f;

    private Vector3 offset;



    // Start is called before the first frame update
    void Start() {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position = Vector3.Lerp(
            gameObject.transform.position,
            player.transform.position                         // Pocetna pozicija
            + (-player.transform.forward * offset.magnitude)  // Stavlja direktno iza
            + new Vector3( 0, offset.y, 0 ),                  // Visina od offseta
            speed * Time.deltaTime);

        gameObject.transform.LookAt(player.transform.position);  // Orijentacija da se fixa
    }
}
