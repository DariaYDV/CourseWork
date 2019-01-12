using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputersCA
{
    public class Computers
    {
        private int index;
        private String model;
        private double price;
        private String CPU;
        private int RAM;
        public Computers() { iIndex = 0; iModel = ""; iPrice = 0; iCPU = ""; iRAM = 0; }
        public int iIndex { get; set; }
        public String iModel { get; set; }
        public double iPrice { get; set; }
        public String iCPU { get; set; }
        public int iRAM { get; set; }
        public override string ToString()
        {
            string myState;
            myState = string.Format("[iIndex = {0}, iModel = {1}, iPrice = {2}, iCPU = {3}, iRAM = {4}]",
                iIndex, iModel, iPrice, iCPU, iRAM);
            return myState;
        }
    }
}
