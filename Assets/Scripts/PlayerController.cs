using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount=1f;
    [SerializeField] float baseSpeed=15f;
    [SerializeField] float boostSpeed=20f;
    [SerializeField] ParticleSystem powerupParticles;
    [SerializeField] ScoreManager scoreManager;
    InputAction moveAction;
    Rigidbody2D myRigidBody2D;
    Vector2 moveVector;
    SurfaceEffector2D surfaceEffector2D;
    bool canControlPlayer=true;
    float previousRotation;
    float totalRotation;
    int flipCount;
    int activePowerupCount;

     
    void Start()
    {
        moveAction=InputSystem.actions.FindAction("Move");
        myRigidBody2D=GetComponent<Rigidbody2D>();
        surfaceEffector2D= FindAnyObjectByType<SurfaceEffector2D>(); //becasue we know there is only one surface effector in the scene
        scoreManager=FindAnyObjectByType<ScoreManager>();
    }

    void Update()
    {
        if (canControlPlayer) //if we are not dead
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
        
        
    }

    void RotatePlayer()
    {
        //Move action give us a vector (x,y) u can see it in control type
        moveVector=moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidBody2D.AddTorque(torqueAmount);
        }
        if (moveVector.x > 0)
        {
            myRigidBody2D.AddTorque(-torqueAmount);
        }
    }

    void BoostPlayer() // boosts if player is pressing up
    {
        if (moveVector.y > 0)
        {
            //increase player speed
            surfaceEffector2D.speed=boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed=baseSpeed;
        }
        
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z; //get current angle in degrees
        totalRotation+=Mathf.DeltaAngle(previousRotation, currentRotation); //calculates delta difference in angle

        //count flips
        if(totalRotation>340 || totalRotation < -340) //should be actually 360 but sometimes we might never reach 360 just close so thats why 340
        {
            flipCount+=1;
            totalRotation=0;
            scoreManager.AddScore(100);
        }
        previousRotation=currentRotation;
    }

    public void DisableControls()
    {
        canControlPlayer=false;
    }


    public void ActivatePowerup(PowerupSO powerup)
    {
        powerupParticles.Play();
        activePowerupCount+=1; //to know how many powerups activated we have
        if(powerup.GetPowerupType() == "speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }

        else if(powerup.GetPowerupType() == "torque")
        {
            torqueAmount += powerup.GetValueChange();
            
        }
    }

    public void DeactivatePowerup(PowerupSO powerup)
    {
        activePowerupCount-=1;

        //we want to deactivate the particles once there arent any powerups active
        if (activePowerupCount == 0)
        {
            powerupParticles.Stop();
        }

        if(powerup.GetPowerupType() == "speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }

        else if(powerup.GetPowerupType() == "torque")
        {
            torqueAmount -= powerup.GetValueChange();
            
        }
        
    }


}
