public class SimpleGoal : Goal
{
private bool _isComplete;

public SimpleGoal(string shortName, string description, int points)
    : base(shortName, description, points)
{
    _isComplete = false;
}

public override void RecordEvent()
{
}

public override bool IsComplete()
{
    return _isComplete;
}

public override string GetStringRepresentation()
{
    return "";
}


}
