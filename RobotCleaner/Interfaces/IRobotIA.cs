using System.Collections.Generic;

namespace RobotCleaner
{
    public interface IRobotIA
    {
        void Start();
        string GetOrientation();
        int GetPositionX();
        int GetPositionY();
        int GetCleanedSpotsQuantity();
    }
}