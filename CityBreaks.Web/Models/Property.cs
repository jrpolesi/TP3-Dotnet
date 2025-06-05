using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CityBreaks.Web.Models;

public class Property
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O preço por noite é obrigatória")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um número positivo")]
    public decimal PricePerNight { get; set; }

    [Required(ErrorMessage = "Selecione uma cidade")]
    public int CityId { get; set; }
    [ValidateNever]
    public City City { get; set; }
    
    public DateTime? DeletedAt { get; set; }
}