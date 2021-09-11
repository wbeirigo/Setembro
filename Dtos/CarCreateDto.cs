using System.ComponentModel.DataAnnotations;

namespace CarService.Dtos
{
    public class CarCreateDto
    {
        [Required]
        public string Marca { get; set; }
 
        [Required]
        public string Modelo { get; set; }
    
        [Required]
        public int Ano { get; set; }
 
        [Required]
        public decimal Preco { get; set; }
    }
}