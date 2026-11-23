using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayReload=1f;
    [SerializeField] ParticleSystem crashParticles;

    PlayerController playerController;

    void Start()
    {
        playerController=FindAnyObjectByType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        int layerIndex=LayerMask.NameToLayer("Floor");
        if(other.gameObject.layer == layerIndex) //checking if we are touching floor with the collision with trigger (on;y 1 w trigger)
        {
            playerController.DisableControls();
            crashParticles.Play();
            Invoke("ReloadScene", delayReload);
    
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0); //reatarts the level 
    }
}
