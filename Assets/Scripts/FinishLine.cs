using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float _loadDelay = 1f;
    [SerializeField] private ParticleSystem _finishEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            _finishEffect.Play();
            Invoke("ReloadScene", _loadDelay);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
