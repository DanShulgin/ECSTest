using UnityEngine;

namespace Services
{
    public interface INavMeshService
    {
        Vector3[] CalculatePath(Vector3 start, Vector3 end);
    }
}