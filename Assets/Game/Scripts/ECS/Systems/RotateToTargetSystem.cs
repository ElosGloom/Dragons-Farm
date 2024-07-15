using Game.Scripts.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.Scripts.ECS.Systems
{
    public class RotateToTargetSystem: IEcsRunSystem
    {
        private EcsFilter<DragonComponent, DragonTargetComponent, MovableComponent>
            _dragonFilter;

        public void Run()
        {
            foreach (var i in _dragonFilter)
            {
                ref var dragonTargetComponent = ref _dragonFilter.Get2(i);
                ref var movableComponent = ref _dragonFilter.Get3(i);

                Vector3 targetPosition = dragonTargetComponent.Target.position;
                
                var navmeshTransform = movableComponent.NavMeshAgent.transform;
                Vector3 lookDirection = targetPosition - navmeshTransform.position;
                lookDirection.y = 0;

                float distanceToTarget =
                    Vector3.Distance(navmeshTransform.position, targetPosition);
                float rotationSpeed = Mathf.Lerp(15f, 1f, distanceToTarget / 10f);

                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                navmeshTransform.rotation = Quaternion.Lerp(
                    navmeshTransform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}