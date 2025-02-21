//El Gobierno Nacional a través de su Ministerio de Salud requiere algunos datos sobre la campaña de vacunación para la mitigación del COVID, 
// en tal sentido se necesitan los siguientes datos:
//•	Listado de ciudadanos que no se han vacunado
//•	Listado de ciudadanos que han recibido las dos vacunas
//•	Listado de ciudadanos que solamente han recibido la vacuna de pfizer
//•	Listado de ciudadanos que solamente han recibido la vacuna de Astrazeneca 
//Para resolver el ejercicio considere lo siguiente:
//•	Cree un conjunto ficticio de 500 ciudadanos
//•	Cree un conjunto ficticio de 75 ciudadanos vacunados con pfizer
//•	Cree un conjunto ficticio de 75 ciudadanos vacunados con astrazeneca

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generar conjunto de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Generar conjuntos de vacunados
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();

        Random random = new Random();
        List<string> ciudadanosList = ciudadanos.ToList();

        // Seleccionar 75 ciudadanos para Pfizer
        while (vacunadosPfizer.Count < 75)
        {
            int index = random.Next(ciudadanosList.Count);
            vacunadosPfizer.Add(ciudadanosList[index]);
        }

        // Seleccionar 75 ciudadanos para Astrazeneca (asegurando que no se repitan con Pfizer)
        while (vacunadosAstrazeneca.Count < 75)
        {
            int index = random.Next(ciudadanosList.Count);
            if (!vacunadosPfizer.Contains(ciudadanosList[index]))
            {
                vacunadosAstrazeneca.Add(ciudadanosList[index]);
            }
        }

        // Listado de ciudadanos que no se han vacunado
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que han recibido las dos vacunas (intersección)
        HashSet<string> ambasVacunas = new HashSet<string>(vacunadosPfizer);
        ambasVacunas.IntersectWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Listado de ciudadanos que solamente han recibido la vacuna de Astrazeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Mostrar resultados
        Console.WriteLine("Ciudadanos no vacunados:");
        Console.WriteLine(string.Join(", ", noVacunados));
        Console.WriteLine("\nCiudadanos con ambas vacunas:");
        Console.WriteLine(string.Join(", ", ambasVacunas));
        Console.WriteLine("\nCiudadanos solo con Pfizer:");
        Console.WriteLine(string.Join(", ", soloPfizer));
        Console.WriteLine("\nCiudadanos solo con Astrazeneca:");
        Console.WriteLine(string.Join(", ", soloAstrazeneca));
    }
}