namespace Journey.Infrastructure.Entities;
public class Trip 
{
    // pegar e setar trip do db browser
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public IList<Activity> Activities { get; set; } = [];
}
