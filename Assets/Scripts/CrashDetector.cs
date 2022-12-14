using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float _loadDelay = 1.5f;
    [SerializeField] private ParticleSystem _crashEffect;
    [SerializeField] private AudioClip CrashSFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            FindObjectOfType<PlayerController>().DisableControl();
            _crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX, 0.5f);
            Invoke("ReloadScene", _loadDelay);
        }
    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
