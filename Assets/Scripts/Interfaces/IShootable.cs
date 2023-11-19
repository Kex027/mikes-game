using UnityEngine;

namespace Interfaces
{
    public interface IShootable
    {
        void Shoot(RaycastHit hit);
    }
}