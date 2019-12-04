using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponManager : MonoBehaviour
{
    private static readonly Vector3 ETHAN_LIGHTSABER_POSITION = new Vector3(0.076f, 0.019f, 0.025f);
    private static readonly Quaternion ETHAN_LIGHTSABER_ROTATION = Quaternion.Euler(-34.34f, 27.591f, 53.099f);
    private static readonly Vector3 ETHAN_LIGHTSABER_SCALE    = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 ETHAN_PISTOL_POSITION     = new Vector3(-0.03f, 0.148f, 0.043f);
    private static readonly Quaternion ETHAN_PISTOL_ROTATION     = Quaternion.Euler(-77.31f, -18.78f, -232.9f);
    private static readonly Vector3 ETHAN_PISTOL_SCALE        = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 ETHAN_RIFLE_POSITION      = new Vector3(-0.059f, 0.171f, 0.018f);
    private static readonly Quaternion ETHAN_RIFLE_ROTATION      = Quaternion.Euler(16.447f, -102.1f, 169.10f);
    private static readonly Vector3 ETHAN_RIFLE_SCALE         = new Vector3(10f, 10f, 10f);

    private static readonly Vector3 BDROID_PISTOL_POSITION    = new Vector3(-0.008f, 0.158f, 0.051f);
    private static readonly Quaternion BDROID_PISTOL_ROTATION    = Quaternion.Euler(-69.192f, -7.936f, 92.683f);
    private static readonly Vector3 BDROID_PISTOL_SCALE       = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 BDROID_RIFLE_POSITION     = new Vector3(-0.037f, 0.278f, 0.023f);
    private static readonly Quaternion BDROID_RIFLE_ROTATION     = Quaternion.Euler(0.542f, -90.44f, 184.74f);
    private static readonly Vector3 BDROID_RIFLE_SCALE        = new Vector3(10f, 10f, 10f);

    private static readonly Vector3 HOOD_LIGHTSABER_POSITION  = new Vector3(0.003f, -0.008f, 0.043f);
    private static readonly Quaternion HOOD_LIGHTSABER_ROTATION  = Quaternion.Euler(1.483f, -37.17f, 21.689f);
    private static readonly Vector3 HOOD_LIGHTSABER_SCALE     = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 HOOD_PISTOL_POSITION      = new Vector3(-0.047f, 0.106f, -0.007f);
    private static readonly Quaternion HOOD_PISTOL_ROTATION      = Quaternion.Euler(-80.07f, -118.3f, 172.04f);
    private static readonly Vector3 HOOD_PISTOL_SCALE         = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 HOOD_RIFLE_POSITION       = new Vector3(-0.013f, 0.203f, 0.022f);
    private static readonly Quaternion HOOD_RIFLE_ROTATION       = Quaternion.Euler(0.022f, 250f, 178.09f);
    private static readonly Vector3 HOOD_RIFLE_SCALE          = new Vector3(12.5f, 12.5f, 12.5f);

    private static readonly Vector3 STORMTROOPER_LIGHTSABER_POSITION = new Vector3(0.043f, 0f, 0.017f);
    private static readonly Quaternion STORMTROOPER_LIGHTSABER_ROTATION = Quaternion.Euler(-34.83f, 70.65f, 22.395f);
    private static readonly Vector3 STORMTROOPER_LIGHTSABER_SCALE    = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 STORMTROOPER_PISTOL_POSITION     = new Vector3(-0.056f, 0.131f, 0.041f);
    private static readonly Quaternion STORMTROOPER_PISTOL_ROTATION     = Quaternion.Euler(-120f, 168.41f, -90.72f);
    private static readonly Vector3 STORMTROOPER_PISTOL_SCALE        = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 STORMTROOPER_RIFLE_POSITION      = new Vector3(-0.064f, 0.2408f, 0.056f);
    private static readonly Quaternion STORMTROOPER_RIFLE_ROTATION      = Quaternion.Euler(163f, 90.06f, -9.041f);
    private static readonly Vector3 STORMTROOPER_RIFLE_SCALE         = new Vector3(10f, 10f, 10f);

    private static readonly Vector3 ALIEN_RIFLE_POSITION             = new Vector3(-0.047f, 0.146f, 0.034f);
    private static readonly Quaternion ALIEN_RIFLE_ROTATION             = Quaternion.Euler(17.528f, 281.5f, 184.4f);
    private static readonly Vector3 ALIEN_RIFLE_SCALE                = new Vector3(10f, 10f, 10f);

    private static readonly Vector3 ALIEN_PISTOL_POSITION            = new Vector3(-0.027f, 0.123f, 0.051f);
    private static readonly Quaternion ALIEN_PISTOL_ROTATION            = Quaternion.Euler(-73.8f, 4.415f, -249f);
    private static readonly Vector3 ALIEN_PISTOL_SCALE               = new Vector3(1f, 1f, 1f);

    private static readonly Vector3 ALIEN_LIGHTSABER_POSITION        = new Vector3(0.047f, -0.029f, 0.046f);
    private static readonly Quaternion ALIEN_LIGHTSABER_ROTATION     = Quaternion.Euler(36.283f, -105.1f, 7.558f);
    private static readonly Vector3 ALIEN_LIGHTSABER_SCALE           = new Vector3(1f, 1f, 1f);

    private static readonly string PISTOL_ANIMATOR_CONTROLLER = "Animations/Pistol Controller";
    private static readonly string RIFLE_ANIMATOR_CONTROLLER = "Animations/Rifle Controller";
    private static readonly string LIGHTSABER_ANIMATOR_CONTROLLER = "Animations/Lightsaber Controller";

    private static readonly string RIGHT_HAND = "mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand";

    private static readonly string HOOD_NAME = "Hood";
    private static readonly string HOOD_PLAYER_NAME = "Hood Player";
    private static readonly string ETHAN_NAME = "Ethan";
    private static readonly string ETHAN_PLAYER_NAME = "Ethan Player";
    private static readonly string STORMTROOPER_NAME = "Stormtrooper";
    private static readonly string STORMTROOPER_PLAYER_NAME = "Stormtrooper Player";
    private static readonly string ALIEN_NAME = "Alien";
    private static readonly string ALIEN_PLAYER_NAME = "Alien Player";
    private static readonly string BDROID_NAME = "B-Droid";
    private static readonly string BDROID_PLAYER_NAME = "B-Droid Player";

    private static readonly double PISTOL_WEAPON_CHANCE = 0.40f;
    private static readonly double RIFLE_WEAPON_CHANCE = 0.10f;

    private KeyCode TOGGLE_KEY_CODE = KeyCode.E;

    public GameObject lightsaber;
    public GameObject pistol;
    public GameObject rifle;

    private System.Random random;
    private GameObject rightHand;
    private GameWeapon currentWeapon;
    private Animator currentAnimator;

    public GameWeapon CurrentWeapon
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        rightHand = transform.Find(RIGHT_HAND).gameObject;
        currentAnimator = GetComponent<Animator>();

        random = new System.Random();
        var choice = random.NextDouble();

        if(choice >= PISTOL_WEAPON_CHANCE)
        {
            EquipPistol();
        }
        else if(choice >= RIFLE_WEAPON_CHANCE || gameObject.tag == BDROID_NAME || gameObject.tag == BDROID_PLAYER_NAME)
        {
            EquipRifle();
        }
        else
        {
            EquipLightsaber();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(TOGGLE_KEY_CODE) && gameObject.tag.Contains("Player"))
        {
            if(currentWeapon != null && currentWeapon.Weapon != null && currentWeapon.Weapon.tag == "Lightsaber")
            {
                currentWeapon.Weapon.transform.Find("Weapon").GetComponent<Weapon>().ToggleWeaponOnOff();
            }
        }
    }

    public void EquipPistol()
    {
        Vector3 position;
        Quaternion rotation;
        Vector3 scale;

        if(gameObject.tag == ALIEN_NAME || gameObject.tag == ALIEN_PLAYER_NAME)
        {
            position = ALIEN_PISTOL_POSITION;
            rotation = ALIEN_PISTOL_ROTATION;
            scale = ALIEN_PISTOL_SCALE;
        }
        else if(gameObject.tag == STORMTROOPER_NAME || gameObject.tag == STORMTROOPER_PLAYER_NAME)
        {
            position = STORMTROOPER_PISTOL_POSITION;
            rotation = STORMTROOPER_PISTOL_ROTATION;
            scale = STORMTROOPER_PISTOL_SCALE;
        }
        else if(gameObject.tag == HOOD_NAME || gameObject.tag == HOOD_PLAYER_NAME)
        {
            position = HOOD_PISTOL_POSITION;
            rotation = HOOD_PISTOL_ROTATION;
            scale = HOOD_PISTOL_SCALE;
        }
        else if(gameObject.tag == ETHAN_NAME || gameObject.tag == ETHAN_PLAYER_NAME)
        {
            position = ETHAN_PISTOL_POSITION;
            rotation = ETHAN_PISTOL_ROTATION;
            scale = ETHAN_PISTOL_SCALE;
        }
        else if(gameObject.tag == BDROID_NAME || gameObject.tag == BDROID_PLAYER_NAME)
        {
            position = BDROID_PISTOL_POSITION;
            rotation = BDROID_PISTOL_ROTATION;
            scale = BDROID_PISTOL_SCALE;
        }
        else
        {
            position = new Vector3(0, 0, 0);
            rotation = Quaternion.Euler(0, 0, 0);
            scale = new Vector3(0, 0, 0);
        }

        createWeapon(pistol, position, rotation, scale, PISTOL_ANIMATOR_CONTROLLER);
    }

    public void EquipRifle()
    {
        Vector3 position;
        Quaternion rotation;
        Vector3 scale;

        if(gameObject.tag == ALIEN_NAME || gameObject.tag == ALIEN_PLAYER_NAME)
        {
            position = ALIEN_RIFLE_POSITION;
            rotation = ALIEN_RIFLE_ROTATION;
            scale = ALIEN_RIFLE_SCALE;
        }
        else if(gameObject.tag == STORMTROOPER_NAME || gameObject.tag == STORMTROOPER_PLAYER_NAME)
        {
            position = STORMTROOPER_RIFLE_POSITION;
            rotation = STORMTROOPER_RIFLE_ROTATION;
            scale = STORMTROOPER_RIFLE_SCALE;
        }
        else if(gameObject.tag == HOOD_NAME || gameObject.tag == HOOD_PLAYER_NAME)
        {
            position = HOOD_RIFLE_POSITION;
            rotation = HOOD_RIFLE_ROTATION;
            scale = HOOD_RIFLE_SCALE;
        }
        else if(gameObject.tag == ETHAN_NAME || gameObject.tag == ETHAN_PLAYER_NAME)
        {
            position = ETHAN_RIFLE_POSITION;
            rotation = ETHAN_RIFLE_ROTATION;
            scale = ETHAN_RIFLE_SCALE;
        }
        else if(gameObject.tag == BDROID_NAME || gameObject.tag == BDROID_PLAYER_NAME)
        {
            position = BDROID_RIFLE_POSITION;
            rotation = BDROID_RIFLE_ROTATION;
            scale = BDROID_RIFLE_SCALE;
        }
        else
        {
            position = new Vector3(0, 0, 0);
            rotation = Quaternion.Euler(0, 0, 0);
            scale = new Vector3(0, 0, 0);
        }

        createWeapon(rifle, position, rotation, scale, RIFLE_ANIMATOR_CONTROLLER);
    }

    public void EquipLightsaber()
    {
        Vector3 position;
        Quaternion rotation;
        Vector3 scale;

        if(gameObject.tag == ALIEN_NAME || gameObject.tag == ALIEN_PLAYER_NAME)
        {
            position = ALIEN_LIGHTSABER_POSITION;
            rotation = ALIEN_LIGHTSABER_ROTATION;
            scale = ALIEN_LIGHTSABER_SCALE;
        }
        else if(gameObject.tag == STORMTROOPER_NAME || gameObject.tag == STORMTROOPER_PLAYER_NAME)
        {
            position = STORMTROOPER_LIGHTSABER_POSITION;
            rotation = STORMTROOPER_LIGHTSABER_ROTATION;
            scale = STORMTROOPER_LIGHTSABER_SCALE;
        }
        else if(gameObject.tag == HOOD_NAME || gameObject.tag == HOOD_PLAYER_NAME)
        {
            position = HOOD_LIGHTSABER_POSITION;
            rotation = HOOD_LIGHTSABER_ROTATION;
            scale = HOOD_LIGHTSABER_SCALE;
        }
        else if(gameObject.tag == ETHAN_NAME || gameObject.tag == ETHAN_PLAYER_NAME)
        {
            position = ETHAN_LIGHTSABER_POSITION;
            rotation = ETHAN_LIGHTSABER_ROTATION;
            scale = ETHAN_LIGHTSABER_SCALE;
        }
        else
        {
            position = new Vector3(0, 0, 0);
            rotation = Quaternion.Euler(0, 0, 0);
            scale = new Vector3(0, 0, 0);
        }

        createWeapon(lightsaber, position, rotation, scale, LIGHTSABER_ANIMATOR_CONTROLLER);
    }

    private void createWeapon(GameObject weapon, Vector3 position, Quaternion rotation, Vector3 scale, string c)
    {
        var clone = Instantiate<GameObject>(weapon);
        clone.transform.parent = rightHand.transform;
        clone.transform.localPosition = position;
        clone.transform.localRotation = rotation;
        clone.transform.localScale = scale;

        currentAnimator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(c);
        currentWeapon = new GameWeapon(clone, 0f);
    }
}
