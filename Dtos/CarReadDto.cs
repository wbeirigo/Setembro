namespace CarService.Dtos
{
    public class CarReadDto
    {

        public int Id { get; set; }
        
        public string Marca { get; set; }
 
        public string Modelo { get; set; }
    
        public int Ano { get; set; }
        public decimal Preco { get; set; }
    }
}