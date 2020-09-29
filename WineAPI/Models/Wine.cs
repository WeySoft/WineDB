using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WineAPI.Models {
public class Wine
    {
    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int year { get; set; }
    [Required]
    public int price { get; set; }
    [Required]
    public string color { get; set; }
    [Required]
    public int amount { get; set; }
    [Required]
    public string grape { get; set; }
    [Required]
    public string spaceID { get; set; }
    [Required]
    public Manufactuer manufactuer { get; set; }
    }
}