using UnityEngine;

namespace Stage
{
	/// <summary>
	/// Collider 컴포넌트가 있는 오브젝트를 대상으로 추가가 가능한 컴포넌트임을 알립니다.
	/// </summary>
	[RequireComponent(typeof(Collider))]
	public class Pickable : MonoBehaviour
	{
		// 오브젝트 회전 속도
		public float rotateSpeed = 20.0f;
		
		// 오브젝트 움직임 속도
		public float upDownSpeed = 5.0f;
		
		void Update()
		{
			// 오브젝트를 빙빙 돌립니다.
			transform.Rotate( Vector3.up * rotateSpeed * Time.deltaTime);
			
			// 오브젝트를 아래위로 둥실둥실 움직이게 합니다.
			transform.position = new Vector3(transform.position.x, 0.3f + 0.1f * Mathf.Sin(Time.time * upDownSpeed),
				transform.position.z);
		}
		
		/// <summary>
		/// 어떤 오브젝트가 Trigger에 걸리게 되면 유니티가 이 콜백을 호출해줍니다.
		/// </summary>
		/// <param name="other"></param>
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