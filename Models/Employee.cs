using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaIntegraMedia.Models
{
    public class Employee
    {

        [HiddenInput(DisplayValue = false)]
        //[Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Legajo")]
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

        public string Full_Name
        {
            get
            {
                return string.Format("{0} {1}", First_Name, Last_Name);
            }
        }

        [DisplayName("Edad")]
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
            try
            {
                int age = 0;
                age = DateTime.Now.Subtract(birthDate).Days;
                age = age / 365;
                return age;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
    }
}
