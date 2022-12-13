using System.ComponentModel.DataAnnotations;

namespace ATEA_coding_challenge.Models;

public class DatabaseEntry
{
    [Key]
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string Entry { get; set; }
}