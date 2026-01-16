public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue(); // Get the next person

        if (person.Turns > 0)
        {
            person.Turns--; // Decrement the turns
            // Re-enqueue only if turns are remaining
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }
        else
        {
            // Infinite turns case, just keep re-enqueuing
            _people.Enqueue(person);
        }

        return person; // Return the dequeued person
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}