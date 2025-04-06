using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour, IHitable
{
    private NavMeshAgent _agent;
    public NavMeshAgent Agent => _agent ??= GetComponent<NavMeshAgent>();

    [SerializeField]Transform _transform;

    [SerializeField]LayerMask _layerMask;
    public Health HealthCompo { get; protected set; }

    Color _color = Color.red;

    private void Awake()
    {
        HealthCompo = GetComponent<Health>();
    }

    private void Update()
    {
        Agent.SetDestination(GameManager.Instance.Player.transform.position);
        bool item = Physics.Linecast(_transform.position, GameManager.Instance.Player.transform.position, _layerMask);
        if (!item)
        {
            _color = Color.green;
        }
        else
        {
            _color = Color.red;
        }
    }
    private void OnDrawGizmos()
    {
        if (GameManager.set)
        {
            Gizmos.color = _color;
            Gizmos.DrawLine(_transform.position, GameManager.Instance.Player.transform.position);
            Gizmos.color = Color.white;
        }
    }

    public virtual void GetHit(int damage)
    {
        HealthCompo.Damaged(damage);
    }
}
