using UnityEngine;
using UnityEngine.AI;

namespace Services
{
    public class NavMeshService : INavMeshService
    {
        public Vector3[] CalculatePath(Vector3 start, Vector3 end)
        {
            var path = new NavMeshPath();
            NavMesh.CalculatePath(start, end, NavMesh.AllAreas, path);
            if (PathExist(path))
            {
                return path.corners;
            }
            return null;
        }
        
        private bool PathExist(NavMeshPath navMeshPath)
        {
            return navMeshPath.status != NavMeshPathStatus.PathInvalid;
        }

        public Vector3 GetPathPointByDistance(Vector3[] path, float pathLength, float distance)
        {
            if (distance <= 0f) return path[0];
            if (distance >= pathLength) return path[path.Length - 1];
            
            var traversedDistance = 0f;
            
            for(var i = 1; i < path.Length; i++)
            {
                var distanceBetweenPoints = traversedDistance + Vector3.Distance(path[i], path[i-1]);
                if(distance < traversedDistance + distanceBetweenPoints)
                {
                    var t = (distance - traversedDistance) / distanceBetweenPoints;
                    return Vector3.Lerp(path[i-1], path[i], t);
                }
                traversedDistance += distanceBetweenPoints;
            }
            return path[path.Length - 1];
        }

        public float GetPathLenght(Vector3[] path)
        {
            var lenght = 0f;
            for (var i = 1; i < path.Length; i++)
            {
                lenght += Vector3.Distance(path[i], path[i-1]);
            }
            return lenght;
        }
    }
}