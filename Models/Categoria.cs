using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectoef.Models;

public class Categoria
{
   // [Key]
    //[MaxLength(150)]
    public Guid CategoriaId { get; set; }

    //[Required]
    public string Nombre { get; set; }
    
    public string Descripcion { get; set;}

    //Fuerza o impacto de la tarea
    public int Peso { get; set;}
    
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas { get; set; }
}