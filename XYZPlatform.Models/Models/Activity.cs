namespace XYZPlatform.Models.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Time> Times { get; set; } = new List<Time>();
}
