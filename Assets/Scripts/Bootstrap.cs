using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Stage
{
	public class Bootstrap : MonoBehaviour
	{
		public GameObject canvas;
		public Text status;
		public Slider slider;
		
		// 게임이 켜지면 호출됩니다.
		IEnumerator Start()
		{
			// 씬 전환시에도 게임오브젝트가 삭제되지 않도록 합니다.
			DontDestroyOnLoad(this.gameObject);
			
			// 화면에 보이는 상태창에 진행상황을 업데이트 합니다.
			SetStatus("Loading", 0f);
			
			// 에셋번들을 로딩할때까지 기다립니다.
			yield return LoadingAssetBundles();
			
			// 모듈을 로딩할때까지 기다립니다.
			yield return LoadingModules();
			
			// 아틀라스는 로드합니다.
			yield return LoadAtlas();

			
			// 로딩이 끝났으니 로비씬으로 이동합니다.
			yield return LoadLobbyScene();
		}

		IEnumerator LoadingAssetBundles()
		{
			SetStatus("Loading Asset Bundles", 0.3f);

			yield return new WaitForSeconds(1.0f);
			
			Debug.Log("AssetBundle Loaded");
		}

		IEnumerator LoadingModules()
		{
			SetStatus("Loading Modules", 0.5f);

			yield return new WaitForSeconds(1.0f);
			
			Debug.Log("Modules Loaded");
		}

		IEnumerator LoadAtlas()
		{
			SetStatus("Atlas", .7f);
			yield return new WaitForSeconds(1.0f);
			
			Debug.Log("Atlas Generated");
			
		}
		
		IEnumerator LoadLobbyScene()
		{
			SetStatus("Loading Lobby...", 0.95f);
			
			yield return SceneManager.LoadSceneAsync("Lobby", LoadSceneMode.Single);
			
			canvas.SetActive(false);
			
			yield return new WaitForSeconds(1.0f);
			
			Debug.Log("Lobby Scene Loaded.");
			Destroy(this.gameObject, 1.0f);
		}

		void SetStatus(string msg, float progress)
		{
			status.text = msg;
			slider.value = progress;
		}
	}
}