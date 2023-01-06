using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Engineer
  {
    public int EngineerId { get; set; }
    [Required(ErrorMessage = "This field cannot be blank! Try again.")]
    public string Name { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}