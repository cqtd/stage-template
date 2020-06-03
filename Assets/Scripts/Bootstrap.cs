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
		
		IEnumerator Start()
		{
			DontDestroyOnLoad(this.gameObject);
			
			SetStatus("Loading", 0f);
			
			yield return LoadingAssetBundles();
			yield return LoadingModules();
			yield return LoadAtlas();

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