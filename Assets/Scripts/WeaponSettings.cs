using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSettings
{
    public static readonly Vector3 ETHAN_LIGHTSABER_POSITION = new Vector3(0.076f, 0.019f, 0.025f);
    public static readonly Quaternion ETHAN_LIGHTSABER_ROTATION = Quaternion.Euler(-34.34f, 27.591f, 53.099f);
    public static readonly Vector3 ETHAN_LIGHTSABER_SCALE    = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 ETHAN_PISTOL_POSITION     = new Vector3(-0.03f, 0.148f, 0.043f);
    public static readonly Quaternion ETHAN_PISTOL_ROTATION     = Quaternion.Euler(-77.31f, -18.78f, -232.9f);
    public static readonly Vector3 ETHAN_PISTOL_SCALE        = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 ETHAN_RIFLE_POSITION      = new Vector3(-0.059f, 0.171f, 0.018f);
    public static readonly Quaternion ETHAN_RIFLE_ROTATION      = Quaternion.Euler(16.447f, -102.1f, 169.10f);
    public static readonly Vector3 ETHAN_RIFLE_SCALE         = new Vector3(10f, 10f, 10f);

    public static readonly Vector3 BDROID_PISTOL_POSITION    = new Vector3(-0.008f, 0.158f, 0.051f);
    public static readonly Quaternion BDROID_PISTOL_ROTATION    = Quaternion.Euler(-69.192f, -7.936f, 92.683f);
    public static readonly Vector3 BDROID_PISTOL_SCALE       = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 BDROID_RIFLE_POSITION     = new Vector3(-0.037f, 0.278f, 0.023f);
    public static readonly Quaternion BDROID_RIFLE_ROTATION     = Quaternion.Euler(0.542f, -90.44f, 184.74f);
    public static readonly Vector3 BDROID_RIFLE_SCALE        = new Vector3(10f, 10f, 10f);

    public static readonly Vector3 HOOD_LIGHTSABER_POSITION  = new Vector3(0.003f, -0.008f, 0.043f);
    public static readonly Quaternion HOOD_LIGHTSABER_ROTATION  = Quaternion.Euler(1.483f, -37.17f, 21.689f);
    public static readonly Vector3 HOOD_LIGHTSABER_SCALE     = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 HOOD_PISTOL_POSITION      = new Vector3(-0.047f, 0.106f, -0.007f);
    public static readonly Quaternion HOOD_PISTOL_ROTATION      = Quaternion.Euler(-80.07f, -118.3f, 172.04f);
    public static readonly Vector3 HOOD_PISTOL_SCALE         = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 HOOD_RIFLE_POSITION       = new Vector3(-0.013f, 0.203f, 0.022f);
    public static readonly Quaternion HOOD_RIFLE_ROTATION       = Quaternion.Euler(0.022f, 250f, 178.09f);
    public static readonly Vector3 HOOD_RIFLE_SCALE          = new Vector3(12.5f, 12.5f, 12.5f);

    public static readonly Vector3 STORMTROOPER_LIGHTSABER_POSITION = new Vector3(0.043f, 0f, 0.017f);
    public static readonly Quaternion STORMTROOPER_LIGHTSABER_ROTATION = Quaternion.Euler(-34.83f, 70.65f, 22.395f);
    public static readonly Vector3 STORMTROOPER_LIGHTSABER_SCALE    = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 STORMTROOPER_PISTOL_POSITION     = new Vector3(-0.056f, 0.131f, 0.041f);
    public static readonly Quaternion STORMTROOPER_PISTOL_ROTATION     = Quaternion.Euler(-120f, 168.41f, -90.72f);
    public static readonly Vector3 STORMTROOPER_PISTOL_SCALE        = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 STORMTROOPER_RIFLE_POSITION      = new Vector3(-0.064f, 0.2408f, 0.056f);
    public static readonly Quaternion STORMTROOPER_RIFLE_ROTATION      = Quaternion.Euler(163f, 90.06f, -9.041f);
    public static readonly Vector3 STORMTROOPER_RIFLE_SCALE         = new Vector3(10f, 10f, 10f);

    public static readonly Vector3 ALIEN_RIFLE_POSITION             = new Vector3(-0.047f, 0.146f, 0.034f);
    public static readonly Quaternion ALIEN_RIFLE_ROTATION             = Quaternion.Euler(17.528f, 281.5f, 184.4f);
    public static readonly Vector3 ALIEN_RIFLE_SCALE                = new Vector3(10f, 10f, 10f);

    public static readonly Vector3 ALIEN_PISTOL_POSITION            = new Vector3(-0.027f, 0.123f, 0.051f);
    public static readonly Quaternion ALIEN_PISTOL_ROTATION            = Quaternion.Euler(-73.8f, 4.415f, -249f);
    public static readonly Vector3 ALIEN_PISTOL_SCALE               = new Vector3(1f, 1f, 1f);

    public static readonly Vector3 ALIEN_LIGHTSABER_POSITION        = new Vector3(0.047f, -0.029f, 0.046f);
    public static readonly Quaternion ALIEN_LIGHTSABER_ROTATION     = Quaternion.Euler(36.283f, -105.1f, 7.558f);
    public static readonly Vector3 ALIEN_LIGHTSABER_SCALE           = new Vector3(1f, 1f, 1f);

    public static readonly string PISTOL_ANIMATOR_CONTROLLER = "Animations/Pistol Controller";
    public static readonly string RIFLE_ANIMATOR_CONTROLLER = "Animations/Rifle Controller";
    public static readonly string LIGHTSABER_ANIMATOR_CONTROLLER = "Animations/Lightsaber Controller";

    public static readonly string RIGHT_HAND = "mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand";

    public static readonly string HOOD_NAME = "Hood";
    public static readonly string ETHAN_NAME = "Ethan";
    public static readonly string STORMTROOPER_NAME = "Stormtrooper";
    public static readonly string ALIEN_NAME = "Alien";
    public static readonly string BDROID_NAME = "B-Droid";

    public static readonly string LIGHTSABER_NAME = "Lightsaber";
    public static readonly string PISTOL_NAME = "Pistol";
    public static readonly string RIFLE_NAME = "Rifle";

    public static readonly float LIGHTSABER_AGENT_DISTANCE = 2;
    public static readonly float PISTOL_AGENT_DISTANCE = 5;
    public static readonly float RIFLE_AGENT_DISTANCE = 7;

    public static readonly Color HOOD_LIGHTSABER_COLOR = Color.blue;
    public static readonly Color ETHAN_LIGHTSABER_COLOR = Color.green;
    public static readonly Color STORMTROOPER_LIGHTSABER_COLOR = Color.yellow;
    public static readonly Color ALIEN_LIGHTSABER_COLOR = Color.magenta;

    public static readonly Dictionary<string, WeaponSettings> LIGHTSABER_MAPPINGS = new Dictionary<string, WeaponSettings>
    {
        [HOOD_NAME]                 = new WeaponSettings{ position=HOOD_LIGHTSABER_POSITION, rotation=HOOD_LIGHTSABER_ROTATION, scale=HOOD_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [ETHAN_NAME]                = new WeaponSettings{ position=ETHAN_LIGHTSABER_POSITION, rotation=ETHAN_LIGHTSABER_ROTATION, scale=ETHAN_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [STORMTROOPER_NAME]         = new WeaponSettings{ position=STORMTROOPER_LIGHTSABER_POSITION, rotation=STORMTROOPER_LIGHTSABER_ROTATION, scale=STORMTROOPER_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [ALIEN_NAME]                = new WeaponSettings{ position=ALIEN_LIGHTSABER_POSITION, rotation=ALIEN_LIGHTSABER_ROTATION, scale=ALIEN_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
    };

    public static readonly Dictionary<string, WeaponSettings> PISTOL_MAPPINGS = new Dictionary<string, WeaponSettings>
    {
        [HOOD_NAME]                 = new WeaponSettings{ position=HOOD_PISTOL_POSITION, rotation=HOOD_PISTOL_ROTATION, scale=HOOD_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [ETHAN_NAME]                = new WeaponSettings{ position=ETHAN_PISTOL_POSITION, rotation=ETHAN_PISTOL_ROTATION, scale=ETHAN_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [BDROID_NAME]               = new WeaponSettings{ position=BDROID_PISTOL_POSITION, rotation=BDROID_PISTOL_ROTATION, scale=BDROID_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [STORMTROOPER_NAME]         = new WeaponSettings{ position=STORMTROOPER_PISTOL_POSITION, rotation=STORMTROOPER_PISTOL_ROTATION, scale=STORMTROOPER_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [ALIEN_NAME]                = new WeaponSettings{ position=ALIEN_PISTOL_POSITION, rotation=ALIEN_PISTOL_ROTATION, scale=ALIEN_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
    };

    public static readonly Dictionary<string, WeaponSettings> RIFLE_MAPPINGS = new Dictionary<string, WeaponSettings>
    {
        [HOOD_NAME]                 = new WeaponSettings{ position=HOOD_RIFLE_POSITION, rotation=HOOD_RIFLE_ROTATION, scale=HOOD_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [ETHAN_NAME]                = new WeaponSettings{ position=ETHAN_RIFLE_POSITION, rotation=ETHAN_RIFLE_ROTATION, scale=ETHAN_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [BDROID_NAME]               = new WeaponSettings{ position=BDROID_RIFLE_POSITION, rotation=BDROID_RIFLE_ROTATION, scale=BDROID_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [STORMTROOPER_NAME]         = new WeaponSettings{ position=STORMTROOPER_RIFLE_POSITION, rotation=STORMTROOPER_RIFLE_ROTATION, scale=STORMTROOPER_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [ALIEN_NAME]                = new WeaponSettings{ position=ALIEN_RIFLE_POSITION, rotation=ALIEN_RIFLE_ROTATION, scale=ALIEN_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
    };

    public static readonly Dictionary<string, Color> LIGHTSABER_COLOR_MAPPINGS = new Dictionary<string, Color>
    {
        [HOOD_NAME]                 = HOOD_LIGHTSABER_COLOR,
        [ETHAN_NAME]                = ETHAN_LIGHTSABER_COLOR,
        [STORMTROOPER_NAME]         = STORMTROOPER_LIGHTSABER_COLOR,
        [ALIEN_NAME]                = ALIEN_LIGHTSABER_COLOR,
    };

    public static readonly Dictionary<System.Tuple<string, string>, WeaponSettings> WEAPON_MAPPINGS = new Dictionary<System.Tuple<string, string>, WeaponSettings>
    {
        [new System.Tuple<string, string>(HOOD_NAME, PISTOL_NAME)]                      = new WeaponSettings{ position=HOOD_PISTOL_POSITION, rotation=HOOD_PISTOL_ROTATION, scale=HOOD_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [new System.Tuple<string, string>(HOOD_NAME, RIFLE_NAME)]                       = new WeaponSettings{ position=HOOD_RIFLE_POSITION, rotation=HOOD_RIFLE_ROTATION, scale=HOOD_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [new System.Tuple<string, string>(HOOD_NAME, LIGHTSABER_NAME)]                  = new WeaponSettings{ position=HOOD_LIGHTSABER_POSITION, rotation=HOOD_LIGHTSABER_ROTATION, scale=HOOD_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ETHAN_NAME, PISTOL_NAME)]                     = new WeaponSettings{ position=ETHAN_PISTOL_POSITION, rotation=ETHAN_PISTOL_ROTATION, scale=ETHAN_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ETHAN_NAME, RIFLE_NAME)]                      = new WeaponSettings{ position=ETHAN_RIFLE_POSITION, rotation=ETHAN_RIFLE_ROTATION, scale=ETHAN_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ETHAN_NAME, LIGHTSABER_NAME)]                 = new WeaponSettings{ position=ETHAN_LIGHTSABER_POSITION, rotation=ETHAN_LIGHTSABER_ROTATION, scale=ETHAN_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [new System.Tuple<string, string>(STORMTROOPER_NAME, PISTOL_NAME)]              = new WeaponSettings{ position=STORMTROOPER_PISTOL_POSITION, rotation=STORMTROOPER_PISTOL_ROTATION, scale=STORMTROOPER_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [new System.Tuple<string, string>(STORMTROOPER_NAME, RIFLE_NAME)]               = new WeaponSettings{ position=STORMTROOPER_RIFLE_POSITION, rotation=STORMTROOPER_RIFLE_ROTATION, scale=STORMTROOPER_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [new System.Tuple<string, string>(STORMTROOPER_NAME, LIGHTSABER_NAME)]          = new WeaponSettings{ position=STORMTROOPER_LIGHTSABER_POSITION, rotation=STORMTROOPER_LIGHTSABER_ROTATION, scale=STORMTROOPER_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ALIEN_NAME, PISTOL_NAME)]                     = new WeaponSettings{ position=ALIEN_PISTOL_POSITION, rotation=ALIEN_PISTOL_ROTATION, scale=ALIEN_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ALIEN_NAME, RIFLE_NAME)]                      = new WeaponSettings{ position=ALIEN_RIFLE_POSITION, rotation=ALIEN_RIFLE_ROTATION, scale=ALIEN_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
        [new System.Tuple<string, string>(ALIEN_NAME, LIGHTSABER_NAME)]                 = new WeaponSettings{ position=ALIEN_LIGHTSABER_POSITION, rotation=ALIEN_LIGHTSABER_ROTATION, scale=ALIEN_LIGHTSABER_SCALE, controllerPath=LIGHTSABER_ANIMATOR_CONTROLLER, navAgentDistance=LIGHTSABER_AGENT_DISTANCE },
        [new System.Tuple<string, string>(BDROID_NAME, PISTOL_NAME)]                    = new WeaponSettings{ position=BDROID_PISTOL_POSITION, rotation=BDROID_PISTOL_ROTATION, scale=BDROID_PISTOL_SCALE, controllerPath=PISTOL_ANIMATOR_CONTROLLER, navAgentDistance=PISTOL_AGENT_DISTANCE },
        [new System.Tuple<string, string>(BDROID_NAME, RIFLE_NAME)]                     = new WeaponSettings{ position=BDROID_RIFLE_POSITION, rotation=BDROID_RIFLE_ROTATION, scale=BDROID_RIFLE_SCALE, controllerPath=RIFLE_ANIMATOR_CONTROLLER, navAgentDistance=RIFLE_AGENT_DISTANCE },
    };

    public static bool IsHood(string tag)
    {
        return tag == HOOD_NAME;
    }

    public static bool IsEthan(string tag)
    {
        return tag == ETHAN_NAME;
    }

    public static bool IsBDroid(string tag)
    {
        return tag == BDROID_NAME;
    }

    public static bool IsStormtrooper(string tag)
    {
        return tag == STORMTROOPER_NAME;
    }

    public static bool IsAlien(string tag)
    {
        return tag == ALIEN_NAME;
    }

    public static bool IsLightsaber(string tag)
    {
        return tag == LIGHTSABER_NAME;
    }

    public static bool IsPistol(string tag)
    {
        return tag == PISTOL_NAME;
    }

    public static bool IsRifle(string tag)
    {
        return tag == RIFLE_NAME;
    }

    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public string controllerPath;
    public float navAgentDistance;
}
