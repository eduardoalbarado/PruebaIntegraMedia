using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIntegraMedia.Models
{
    public class Client
    {
        [HiddenInput(DisplayValue = false)]
        //[Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Legajo")]
        [Required]
        public int Employee_Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50)]
        public string First_Name { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(50)]
        public string Last_Name { get; set; }

        [DisplayName("DNI")]
        [Required(ErrorMessage = "DNI es requerido")]
        [Range(1000000, 99999999, ErrorMessage = "Precio debe estar entre 1000000 y 99999999")]
        public int Document { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required(ErrorMessage = "Fecha de Nacimiento es requerido")]
        public DateTime DateOfBirthday { get; set; }

        [DisplayName("Activo")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        public virtual int Age
        {
            get
            {
                try
                {
                    return CalculateAge(DateOfBirthday);
                }
                catch (Exception)
                {
                    return 0;
                    throw;
                }


            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime n = DateTime.Now;
            int age = n.Year - birthDate.Year;

            if (n.Month < birthDate.Month || (n.Month == birthDate.Month && n.Day < birthDate.Day))
                age--;

            return age;
        }

        [Display(Name = "Tarjeta de Credito")]
        [Required]
        [DataType(DataType.CreditCard)]
        public String CreditCard { get; set; }



    }
}
