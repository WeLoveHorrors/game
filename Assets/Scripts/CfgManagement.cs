using SharpConfig;
using System.IO;
using UnityEngine;  

public class CfgManagement : MonoBehaviour
{
	public static float audioLevel { 
		get { return cfg["Audio"]["AudioLevel"].FloatValue; }
		set { cfg["Audio"]["AudioLevel"].FloatValue = value; }
	}
	public static float musicLevel { 
		get { return cfg["Audio"]["MusicLevel"].FloatValue; }
		set { cfg["Audio"]["MusicLevel"].FloatValue = value; }
	}
	public static float soundLevel { 
		get { return cfg["Audio"]["SoundLevel"].FloatValue; }
		set { cfg["Audio"]["SoundLevel"].FloatValue = value; }
	}
	public static float mouseSensitivity { 
		get { return cfg["Mouse"]["Sensitivity"].FloatValue; }
		set { cfg["Mouse"]["Sensitivity"].FloatValue = value; }
	}

	public static Configuration cfg = new Configuration();

	void Start()
	{
		if (!File.Exists("config.cfg"))
		{
			Debug.Log("Setting up a default config since no file was found!");
			SetupCleanCFG();
			SaveConfig();
		}

		// Load the configuration.
		cfg = Configuration.LoadFromFile("config.cfg");
	}

	public void SaveConfig()
	{
		Debug.Log("Saving Client config...");

		// Save the configuration.
		cfg.SaveToFile("config.cfg");
	}

	private void SetupCleanCFG()
	{
		cfg["Mouse"]["Sensitivity"].FloatValue = 1f;
		cfg["Audio"]["AudioLevel"].FloatValue = 0.5f;
		cfg["Audio"]["MusicLevel"].FloatValue = 0.5f;
		cfg["Audio"]["SoundLevel"].FloatValue = 0.5f;
	}
}
