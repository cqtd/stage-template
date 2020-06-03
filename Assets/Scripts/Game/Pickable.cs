using UnityEngine;

namespace Stage
{
	[RequireComponent(typeof(Collider))]
	public class Pickable : MonoBehaviour
	{
		public float rotateSpeed = 20.0f;
		public float upDownSpeed = 5.0f;
		
		void Update()
		{
			transform.Rotate( Vector3.up * rotateSpeed * Time.deltaTime);
			transform.position = new Vector3(transform.position.x, 0.3f + 0.1f * Mathf.Sin(Time.time * upDownSpeed),
				transform.position.z);
		}
		
		void OnTriggerEnter(Collider other)
		{
			var pc = other.GetComponent<PlayerController>();
			if (pc != null)
				TriggerEnter(pc);
		}

		protected virtual void TriggerEnter(PlayerController pc)
		{
			
		}
	}
}