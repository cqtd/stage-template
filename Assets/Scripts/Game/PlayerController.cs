using UnityEngine;
using UnityEngine.AI;

namespace Stage
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class PlayerController : MonoBehaviour
	{
		// 필요한 오브젝트들을 임시로 캐싱해 놓습니다.
		// 카메라
		Camera currentCamea;
		// 캐릭터를 자동으로 움직이기 위한 네비 메시 에이전트
		NavMeshAgent agent;

		// 이 컨트롤러가 초기화 되었는지 확인하는 플래그
		bool initialized = false;
		
		// 레이캐스트에 사용하게 될 레이어 설정을 인스펙터에 하기 위해 public 으로 뽑아둡니다.
		public LayerMask groundLayer;

		// 에디터에서 비주얼 디버깅을 위해 사용합니다.
		Vector3 debugPos;
		Color debugColor;

		// 초기화
		void Start()
		{
			Initialize();
		}

		void Initialize()
		{
			if (!initialized)
			{
				currentCamea = Camera.main;
				agent = GetComponent<NavMeshAgent>();
				
				initialized = true;
			}
		}

		void Update()
		{
			if (!initialized) return;
			
			// 마우스 왼클릭이 눌리면
			if (Input.GetMouseButton(0))
			{
				// 레이를 만들고,
				Ray ray = currentCamea.ScreenPointToRay(Input.mousePosition);
				
				// 쏩니다.
				if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundLayer))
				{
					// 이 안으로 들어왔다면 맞았다는 뜻이며, MoveTo 시킵니다.
					MoveTo(hit.point);
					debugPos = hit.point;
				}
				
				debugColor = Color.yellow;
			}
			else
			{
				debugColor = Color.red;
			}
		}

		void OnDrawGizmos()
		{
			Gizmos.color = debugColor;
			Gizmos.DrawSphere(debugPos, 0.4f);
		}

		// 간단히 네비 매시 에이전트에게 목적지만 설정해줍니다.
		void MoveTo(Vector3 pos)
		{
			agent.SetDestination(pos);
		}
	}
}