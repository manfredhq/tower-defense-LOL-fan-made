using UnityEngine;

public class BasicAttackScript : MonoBehaviour
{

    public Animator anim;
    public Turret turret;

    private void Update()
    {
        if (turret.target == null)
        {
            anim.Play("New State");
        }
    }

    public void PlayAttackAnimation(float fireRate, string animationName = "BasicAttack")
    {
        anim.speed = fireRate;
        anim.Play(animationName);
    }
}
