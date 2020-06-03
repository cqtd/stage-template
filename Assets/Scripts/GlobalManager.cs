using UnityEngine;

namespace Stage
{
	public class GlobalManager : MonoBehaviour
	{
		readonly Vector2[] resolutions = new[]
		{
			new Vector2(1280, 720),
			new Vector2(1600, 900),
			new Vector2(1920, 1080),
		};

		int currentRes = 0;
		
		void Awake()
		{
			Screen.fullScreenMode = FullScreenMode.Windowed;
			SetRes(resolutions[currentRes]);
			
			DontDestroyOnLoad(this.gameObject);
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				currentRes = (currentRes - 1 + resolutions.Length) % resolutions.Length;
				SetRes(resolutions[currentRes]);
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				currentRes = (currentRes + 1) % resolutions.Length;
				SetRes(resolutions[currentRes]);
			}
		}

		void SetRes(Vector2 v)
		{
			Screen.SetResolution((int) v.x, (int) v.y, FullScreenMode.Windowed);
		}
	}
}