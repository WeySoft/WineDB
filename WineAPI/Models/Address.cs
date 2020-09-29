using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WineAPI.Models {
public class Address
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Land { get; set; }
    public int PostalCode { get; set; }
    [Required]
    public string Location { get; set; }
    [JsonIgnore]
    public IEnumerable<Manufactuer> Manufactuers { get; set; }
    }
}