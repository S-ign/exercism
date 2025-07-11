abstract class Character
{
    private string _charType = "";
    protected bool vulnerable = false;

    protected Character(string characterType) => _charType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => vulnerable;

    public override string ToString() => $"Character is a {_charType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable()) {
            return 10;
        } 
        return 6;
    }
}

class Wizard : Character
{
    private bool _spellPrepared = false;

    public Wizard() : base("Wizard")
    {
        base.vulnerable = true;
    }

    public override int DamagePoints(Character target)
    {
        if (_spellPrepared) {
            _spellPrepared = false;
            base.vulnerable = true;
            return 12;
        } 
        return 3;
    }

    public void PrepareSpell() {
        _spellPrepared = true;
        base.vulnerable = false;
    }
}
