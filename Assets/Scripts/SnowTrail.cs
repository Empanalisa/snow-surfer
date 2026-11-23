using UnityEngine;

public class SnowTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem playerParticles;

    private void OnCollisionEnter2D(Collision2D other) {
        int layerIndex=LayerMask.NameToLayer("Floor");
        if(other.gameObject.layer == layerIndex)
        {
            playerParticles.Play();
        }
   
    }

    private void OnCollisionExit2D(Collision2D other) {
        int layerIndex=LayerMask.NameToLayer("Floor");
        if(other.gameObject.layer == layerIndex)
        {
            playerParticles.Stop();
        }
    }
}
