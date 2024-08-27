namespace TodoAPI.Models
{
    public class TodoList
    {
        public int IdTarea { get; set; }
        public string? titulo { get; set; }    
        public string? descripcion { get; set; }
        public string? estado { get; set; }
        public DateTime Creado_en { get; set; }
        public DateTime Actualizado_en { get; set; }


    }
}
