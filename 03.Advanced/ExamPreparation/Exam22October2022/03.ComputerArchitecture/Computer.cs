using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor  { get; set; }
        public int Count { get { return Multiprocessor.Count; } }

        public void Add(CPU cpu)
        {
            if (Count + 1 <= Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    Multiprocessor.Remove(cpu);
                    return true;
                }
            }

            return false;
        }

        public CPU MostPowerful()
        {
            double highestFrequency = double.MinValue;
            CPU mostPowerfulCPU = null;

            foreach (CPU cpu in Multiprocessor) 
            {
                if (cpu.Frequency > highestFrequency)
                {
                    highestFrequency = cpu.Frequency;
                    mostPowerfulCPU = cpu;
                }
            }

            return mostPowerfulCPU;
        }

        public CPU GetCPU(string brand)
        {
            foreach (var cpu in Multiprocessor)
            {
                if (cpu.Brand == brand)
                {
                    return cpu;
                }
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}