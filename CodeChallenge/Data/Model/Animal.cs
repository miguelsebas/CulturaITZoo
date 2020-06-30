using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Data.Model
{
    public class Animal
    {
        [Key]
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }

        [Display(Name ="Lugar de Origen")]
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public double Porcentaje { get; set; }
        public double Kilos { get; set; }
        [Display(Name = "Cambio de Piel")]
        public int? DiasRep { get; set; }

        public double CalcularAlimento()
        {
            int? dias = DateTime.DaysInMonth(DateTime.Now.Year ,DateTime.Now.Month);
            var total = 0D;
            if (Tipo == "Carnívoro")
            {
                total += (Peso * Porcentaje);                
            }
            else if (Tipo == "Herbíboro")
            {
                total += ((2 * Peso) + Kilos);
            }
            else if (Tipo == "Reptil")
            {
                if (DiasRep != 0)
                {
                    var diasDiscount = DiasRep * 3;
                    dias -= diasDiscount;
                    total += (Peso * Porcentaje);
                }
            }
            return total;
        }

    }
}