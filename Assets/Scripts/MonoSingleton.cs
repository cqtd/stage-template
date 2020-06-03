using UnityEngine;

namespace Stage
{
	/// <summary>
	/// Singleton Pattern for MonoBehaviour
	/// </summary>
	/// <typeparam name="T">Target Class Type</typeparam>
	public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
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
		/// Fast Enter Play Mode Integration
		/// </summary>
		[RuntimeInitializeOnLoadMethod]
		static void ResetDomain()
		{
			instance = null; 
		}

		protected virtual void OnDestroy()
		{
			instance = null;
		}
	}
}