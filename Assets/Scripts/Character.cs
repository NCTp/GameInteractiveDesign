using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Projectile projectile_Normal;
    public Projectile projectile_Thunder;
    public Projectile projectile_FireBall;
    public Projectile projectile_Stone;

    public float shootTime = 1.0f;
    private float shootReadyTime = 0.0f;

    public bool isShootNormalSkill = false;

    private Animator _animator;
    public void Skill(string skillName)
    {
        switch (skillName)
        {
            case ("Thunder"):
                _animator.SetBool("isCasting", true);
                //Projectile _projectile_Thunder = Instantiate(projectile_Thunder, transform.position, transform.rotation);
                break;
            case ("FireBall"):
                _animator.SetBool("isCastingFireBall", true);
                break;
            case ("Stone"):
                Projectile _projectile_Stone = Instantiate(projectile_FireBall, transform.position, transform.rotation);
                break;
            default:
                break;
                
        }
    }

    public void Skill_Thunder()
    {
        Projectile _projectile_Thunder = Instantiate(projectile_Thunder, transform.position, transform.rotation);
        _animator.SetBool("isCasting", false);
    }
    public void Skill_FireBall()
    {
        Projectile _projectile_FireBall = Instantiate(projectile_FireBall, transform.position, transform.rotation);
        _animator.SetBool("isCastingFireBall", false);
    }

    public void NormalSkill()
    {
        Projectile _projectile_Normal = Instantiate(projectile_Normal, transform.position, transform.rotation);
        _animator.SetBool("isCasting", true);
    }

    public void SetCastingNormalSkillFalse()
    {
        _animator.SetBool("isCasting", false);
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Skill("Thunder");
        if(isShootNormalSkill) InvokeRepeating("NormalSkill", 0f, shootTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
