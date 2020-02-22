namespace RobotCleaner.Test
{
    internal interface IRobotIA
    {
        void Start();
        string GetOrientation();
        int GetPositionX();
        int GetPositionY();
    }
}