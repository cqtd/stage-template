using UnityEngine;

namespace Stage
{
	public class GlobalManager : MonoBehaviour
	{
		// 사용가능한 해상도 모음
		readonly Vector2[] resolutions = new[]
		{
			new Vector2(1280, 720),
			new Vector2(1600, 900),
			new Vector2(1920, 1080),
		};

		int currentRes = 2;
		
		void Awake()
		{
			// 윈도우 모드로 바꿉니다.
			Screen.fullScreenMode = FullScreenMode.Windowed;
			SetRes(resolutions[currentRes]);
			
			DontDestroyOnLoad(this.gameObject);
		}

		void Update()
		{
			// ESC 가 눌리면
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				// 게임종료
				Application.Quit();
			}

			// 아래 키 눌리면
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				// 해상도 줄이기
				currentRes = (currentRes - 1 + resolutions.Length) % resolutions.Length;
				SetRes(resolutions[currentRes]);
			}

			// 위 키 눌리면
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				// 해상도 늘리기
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