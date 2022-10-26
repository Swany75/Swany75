using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public Text txtItems;
    public Text txtWinner;
    public Text txtLoser;
    public int itemCount;
    private int totalItems;
    void Start() {
        itemCount = 0;
        txtItems.text = "Items: " + itemCount;
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
    }

    void Update() {
        
    }

    public void updateItemCount() {
        itemCount++;
        txtItems.text = "Items: " + itemCount;

        if (itemCount >= totalItems) {
            Debug.Log("Victoria");
            txtWinner.gameObject.SetActive(true);
            Invoke("nextlevel", 2f);
        }
    }

    public void gameOver() {
        Debug.Log("Derrota");
        txtLoser.gameObject.SetActive(true);
        Invoke("resetlevel", 2f);
    }

    void resetLevel() {
        SceneManager.LoadScene(0);
    }

    void nextLevel() {
        if (SceneManager.GetActiveScene().buildIndex < 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else 
            SceneManager.LoadScene(0);
    }
}
