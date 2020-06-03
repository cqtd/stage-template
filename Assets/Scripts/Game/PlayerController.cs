using UnityEngine;
using UnityEngine.AI;

namespace Stage
{
	[RequireComponent(typeof(NavMeshAgent))]
	public class PlayerController : MonoBehaviour
	{
		Camera currentCamea;
		NavMeshAgent agent;

		bool initialized = false;
		
		public LayerMask groundLayer;

		Vector3 debugPos;
		Color debugColor;

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
			
			if (Input.GetMouseButton(0))
			{
				Ray ray = currentCamea.ScreenPointToRay(Input.mousePosition);
				
				if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, groundLayer))
				{
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

		void MoveTo(Vector3 pos)
		{
			agent.SetDestination(pos);
		}
	}
}