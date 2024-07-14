using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class ReadMCDto
    {
        public int id { get; set; }
        public string modelo { get; set; }
       
        public int ano { get; set; }
       
        public string valvulas { get; set; }
   
        public string cambio { get; set; }
      
        public string carroceria { get; set; }
       
        public string produto { get; set; }
        public string codProdOriginal { get; set; }
    }
}
