using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private float hInput, vInput;
    private float moveSpeed = 35f;
    private float rotateSpeed = 40f;
    private float jumpSpeed = 80f;
    private bool isGrounded;
    private bool isDead;
    private Rigidbody rb;
    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>(); 
    }
    
    void Update() {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angelRot = Quaternion.Euler(rotation * Time.deltaTime);

        rb.MovePosition(transform.position +(transform.forward * vInput * Time.deltaTime));
        rb.MoveRotation(rb.rotation * angelRot);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpSpeed);
            isGrounded = false;
        }

        if (this.transform.position.y < -10 && !isDead) {
            isDead = true;
        GameObject.Find("GameManager").GetComponent<GameManager>().gameOver();
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Item")) {
            GameObject.Find("GameManager").GetComponent<GameManager>().updateItemCount();
            Destroy(col.gameObject);
       
       }
    }   

}
