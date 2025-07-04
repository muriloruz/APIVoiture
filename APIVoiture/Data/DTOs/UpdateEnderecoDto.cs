﻿using System.ComponentModel.DataAnnotations;

namespace APIVoiture.Data.DTOs
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "cep required")]
        [MinLength(8, ErrorMessage = "max and minimal chars of cep is 8")]
        [MaxLength(8, ErrorMessage = "max and minimal chars of cep is 8/")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "rua required")]
        [StringLength(65, ErrorMessage = "max size of rua is 65")]
        public string rua { get; set; }
        [Required(ErrorMessage = "bairro required")]
        [StringLength(65, ErrorMessage = "max size of bairro is 65")]
        public string bairro { get; set; }
        [Required(ErrorMessage = "cidade required")]
        [StringLength(40, ErrorMessage = "max size of cidade is 40")]
        public string cidade { get; set; }
        
       
        [Required(ErrorMessage = "uf required")]
        [StringLength(2, ErrorMessage = "max size of uf is 2")]
        public string uf { get; set; }
    }
}
