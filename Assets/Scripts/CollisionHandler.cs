using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour{
private void OnTriggerEnter(Collider other) {
         {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("gameOverScreen");
        }

        else if (other.gameObject.tag == "Scorer")
        {
            FindObjectOfType<TextScore>().IncreaseScore();
        }
    }
}
}