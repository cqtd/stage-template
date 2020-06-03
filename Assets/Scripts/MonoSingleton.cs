using UnityEngine;

namespace Stage
{
	/// <summary>
	/// Singleton Pattern for MonoBehaviour
	/// </summary>
	/// <typeparam name="T">Target Class Type</typeparam>
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		/// <summary>
		/// 상속간에 스크립트에서 자동으로 돈 디스트로이 온 로드에 추가할 수 있도록 만든 장치
		/// </summary>
		/// <returns></returns>
		protected virtual bool DoNotDestroyOnLoad()
		{
			return false;
		}
		
		protected static T instance;
		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType(typeof(T)) as T;
					if (instance == null)
					{
						instance = new GameObject($"[{typeof(T)}]", typeof(T)).GetComponent<T>();
					}
				}
				return instance;
			}
		}

		protected virtual void Awake()
		{
			if (DoNotDestroyOnLoad())
				DontDestroyOnLoad(this.gameObject);
		}

		/// <summary>
		/// Fast EnterPlayMode를 사용하기 위해 있는 것입니다. 신경안쓰셔도됩니다.
		/// Fast Enter Play Mode Integration
		/// </summary>
		[RuntimeInitializeOnLoadMethod]
		static void ResetDomain()
		{
			instance = null; 
		}

		/// <summary>
		/// 삭제 가능한 싱글턴인경우 instance 를 명시적으로 비워줍니다.
		/// </summary>
		protected virtual void OnDestroy()
		{
			instance = null;
		}
	}
}