using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Car
    {

        [Key]
        [Required]
        public int Id { get; set; }
        
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