﻿using APIVoiture.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APIVoiture.Models;

public class Vendedor : ApplicationUser
{
   

    
    [Required(ErrorMessage = "cnpj is required")]
    [MinLength(14,ErrorMessage = "max and minimal chars of cnpj is 14")]
    [MaxLength(14, ErrorMessage = "max and minimal chars of cnpj is 14")]
    public string cnpj { get; set; }
    [Required]
    public string telefoneVend { get; set; }
    public double avaliacao { get; set; }
    public int numDeAvaliacao { get; set; }
    public long numCasa {  get; set; }

    public string complemento { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string RePassword { get; set; }




    public virtual ICollection<Peca> Pecas { get; set; }

    public virtual ICollection<VendedorCliente> VendedorCliente { get; set; } 

    public int EnderecoId { set; get; } 
    public virtual Endereco Endereco { get; set; }

    public Vendedor() : base()
    {

    }
}
