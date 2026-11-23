using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;

    PlayerController player;
    SpriteRenderer spriteRenderer;
    float timeLeft;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        timeLeft=powerup.GetTime();
    }

    void Update()
    {
        CountdownTimer();
    }

    void CountdownTimer()
    {
        if (spriteRenderer.enabled == false) //starts decreasing when the powerup item is disabled (lo agarraste therefore u cant see it)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime; //how long the current frame took in our game
                if (timeLeft <= 0)//we reach 0 so it only happens once
                {
                    //Deactivate powerup
                    player.DeactivatePowerup(powerup);
                }
            }  
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(other.gameObject.layer==layerIndex && spriteRenderer.enabled)
        {
            //Make the powerup dissapear
            spriteRenderer.enabled=false;
            //initialize powerup
            player.ActivatePowerup(powerup);
        }
    }
}
