﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Models
{
    public class ProdutoViewModel
    {
        
        [Required]//obriga a inserção do campo
        public int Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Display (Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }//inteiro alunável que pode aceitar nulos
                                             //public nullable <int> CategoriaId { get; set; }//inteiro alunável que pode aceitar nulos


        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();//estanciamento na property

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

    }
}