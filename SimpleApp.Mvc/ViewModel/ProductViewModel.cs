using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleApp.Mvc.ViewModel
{
	public class ProductViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter entre 5 e 100 caracteres")]
		[Display(Name = "Nome")]
		public string Name { get; set; } 

		[Required(ErrorMessage = "O campo Nome é obrigatório")]
		[StringLength(200, MinimumLength = 5, ErrorMessage = "O campo Descrição deve ter entre 5 e 200 caracteres")]
		[Display(Name = "Descrição")]
		public string Description { get; set; }
	}
}