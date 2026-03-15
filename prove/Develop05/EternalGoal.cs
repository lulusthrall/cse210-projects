using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals never finish, they just grant points each time.
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return "EternalGoal:" + GetName() + "," + GetPoints();
    }
}