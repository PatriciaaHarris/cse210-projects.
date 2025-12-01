using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life.";
        _duration = 0;

        _count = 0;
        _prompts = new List<string>();
    }

    public void Run()
    {
       
    }

    public string GetRandomPrompt()
    {
        return ""; 
    }

    public List<string> GetListFromUser()
    {
        return new List<string>(); 
    }
}
