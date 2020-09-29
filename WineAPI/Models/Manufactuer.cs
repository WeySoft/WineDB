using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WineAPI.Models {
public class Manufactuer
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    public Address address { get; set; }
    [JsonIgnore]
    public IEnumerable<Wine> Wines { get; set; }
    }
}