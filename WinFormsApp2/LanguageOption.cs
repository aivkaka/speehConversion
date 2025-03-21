public class LanguageOption
{
    public int Id { get; set; } 
    public string Language { get; set; } 

    public override string ToString()
    {
        return Language; 
    }
}