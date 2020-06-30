using CodeChallenge.Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        public List<Animal> _animales;

        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }

        public List<string> TiposAnimales => new List<string>() { "Carnívoro", "Herbíboro", "Reptil" };

        public void AgregarAnimal(Animal animal)
        {
            _animales.Add(animal);
        }

        public List<Animal> TraerTodosAnimales()
        {
            return _animales;
        }

        public double TotalCarnesCarnivoro()
        {
            var totalCarne = _animales.Where(x => x.Tipo == "Carnívoro").Sum(c => c.CalcularAlimento());
            return totalCarne;
        }
        public double TotalHierbaHerbiboros()
        {
            var totalCarne = _animales.Where(x => x.Tipo == "Herbíboro").Sum(c => c.CalcularAlimento());
            return totalCarne;
        }
        public double TotalCarnesReptil()
        {
            var totalCarne = _animales.Where(x => x.Tipo == "Reptil").Sum(c => c.CalcularAlimento());
            return totalCarne;
        }

        public double TraerTotalKilosCorrienteMes()
        {
            return _animales.Sum(x => x.Kilos);
        }

        public bool CheckCantidadKilos(Animal animal)
        {
            var dias = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var totalCarnivoroHerbivoro = 0D;
            var totalReptiles = 0D;
            var total = 0D;
            totalCarnivoroHerbivoro = _animales.Where(x => x.Tipo == "Herbívoro" || x.Tipo == "Carnívoro")
                .Sum(c => c.CalcularAlimento()) + animal.CalcularAlimento();
            var reptiles = _animales.Where(x => x.Tipo == "Reptil");

            foreach (var item in reptiles)
            {
                var day = dias - (item.DiasRep * 3);
                double tot = Convert.ToDouble(reptiles.Sum(x => x.CalcularAlimento()) * day);
                totalReptiles += tot;
            }

            total = (totalCarnivoroHerbivoro * dias) + totalReptiles;

            if (total > 1500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
