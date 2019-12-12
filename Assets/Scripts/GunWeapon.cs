using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(AudioSource))]
public class GunWeapon : GameWeapon
{
    [SerializeField]
    private GameObject bullet = null;

    [SerializeField]
    private float maxDamage = 0f;

    [SerializeField]
    private float minDamage = 0f;

    [SerializeField]
    private float timeBetweenShots = 0f;

    [SerializeField]
    private int maxClipSize = 0;

    [SerializeField]
    private float reloadTime = 0f;

    public List<AudioClip> sounds;
    public AudioClip reloadSound;

    private float untilCanShoot;
    private int currentClip;
    private bool reloading;
    private AudioSource audio;

    public int CurrentClip
    {
        get { return currentClip; }
        set { currentClip = value; }
    }

    public bool Reloading
    {
        get { return reloading; }
        set { reloading = value; }
    }

    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    public int MaxClipSize
    {
        get { return maxClipSize; }
        set { maxClipSize = value; }
    }

    public float TimeBetweenShots
    {
        get { return timeBetweenShots; }
        set { timeBetweenShots = value; }
    }

    public float MinDamage
    {
        get { return minDamage; }
        set { minDamage = value; }
    }

    public float MaxDamage
    {
        get { return maxDamage; }
        set { maxDamage = value; }
    }

    void Start()
    {
        Assert.IsNotNull(bullet);
        untilCanShoot = Time.time;
        currentClip = maxClipSize;
        audio = GetComponent<AudioSource>();
    }

    override public void Attack()
    {
        if(CanAttack())
        {
            untilCanShoot = Time.time + timeBetweenShots;
            var realBullet = Instantiate<GameObject>(bullet, OwnerHand.transform.position, Owner.transform.rotation);
            realBullet.GetComponent<Bullet>().Owner = Owner;
            realBullet.GetComponent<Bullet>().Damage = Random.Range(MinDamage, MaxDamage);
            CurrentClip--;
            if(sounds.Count > 0)
            {
                audio.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
            }
        }
    }

    override public bool CanAttack()
    {
        return !OnCooldown() && !NeedToReload() && !reloading;
    }

    public bool OnCooldown()
    {
        return untilCanShoot >= Time.time;
    }

    public bool NeedToReload()
    {
        return currentClip == 0;
    }

    public void Reload()
    {
        reloading = false;
        CurrentClip = MaxClipSize;
    }

    public void PlayReloadSound()
    {
        if(reloadSound != null)
        {
            audio.PlayOneShot(reloadSound);
        }
    }
}
