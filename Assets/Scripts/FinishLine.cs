using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayReload=1f;
    [SerializeField] ParticleSystem finishParticles;

    private void OnTriggerEnter2D(Collider2D other) {
        int layerIndex=LayerMask.NameToLayer("Player");
        if(other.gameObject.layer == layerIndex)// if both object layers are the same means we have players object collisioning
        {
            finishParticles.Play();
            Invoke("ReloadScene", delayReload); //reatarts the level when touch finish line
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


}
