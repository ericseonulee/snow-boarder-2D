using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float _loadDelay = 1.5f;
    [SerializeField] private ParticleSystem _crashEffect;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            _crashEffect.Play();
            Invoke("ReloadScene", _loadDelay);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
