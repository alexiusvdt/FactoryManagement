using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    [Required(ErrorMessage = "This field cannot be blank! Try again.")]
    public string Name { get; set; }
    public List<EngineerMachine> JoinEntities { get; }
  }
}