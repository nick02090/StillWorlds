using Gameplay.Interactors;
using UnityEngine;

namespace Gameplay.Characters
{
    public interface ICharacter
    {
        float GetMovementSpeed();
        float GetRotationSpeed();
        Interactor GetInteractor();
        Portal GetPortal();
        int GetLife();
        void SetLife(int life);
        void Attack();
        void TakeHit();
        int GetKill();
        void SetKill(int kill);
        float GetVisionDistance();
        float GetHearingDistance();
        float GetVisionAngle();
        SearchPath GetSearchPath();
        void SetRotation(Quaternion rotation);
        Vector3 GetSpawnLocation();
    }
}