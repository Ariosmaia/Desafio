using EmployeeRegistration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace EmployeeRegistration.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore]
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get;  set; }

        [Required(ErrorMessage = "O sobrenome é requirido")]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get;  set; }

        [Required(ErrorMessage = "A data de aniversário é requirida")]
        public DateTime BirthDate { get;  set; }

        [Required(ErrorMessage = "O e-mail é requirido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "O sexo é requerido")]
        public EGender Gender { get;  set; }

        [Required(ErrorMessage = "Informe pelo menos uma habilidade")]
        public List<SkillViewModel> Skills { get;  set; }
    }
}
