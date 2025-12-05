public class ChecklistGoal : Goal
{
private int _amountCompleted;
private int _target;
private int _bonus;

public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
    : base(shortName, description, points)
{
    _amountCompleted = 0;
    _target = target;
    _bonus = bonus;
}

public override void RecordEvent()
{
}

public override bool IsComplete()
{
    return _amountCompleted >= _target;
}

public override string GetDetailsString()
{
    string checkbox = IsComplete() ? "[X]" : "[ ]";
    return $"{checkbox} {_shortName} ({_description}) -- Currently: {_amountCompleted}/{_target}";
}

public override string GetStringRepresentation()
{
    return "";
}


}
