using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
   private float speed = 0.5f;
    void Update() {
        transform.Rotate(new Vector3(45,45,45) * speed * Time.deltaTime);
    }
}
