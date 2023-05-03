﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMangement.Model
{
    public class PolyModel
    {
        private int id;
        private string machine;
        private int pca;
        private int xinhua;
        private int aspoly;
        private int arpoly;
        private int hemlock;

        private int asDopant;
        private int phDopant;
        private int bDopant;

        private DateTime time;

        

        public int Id { get => id; set => id = value; }
        public string Machine { get => machine; set => machine = value; }
        public int Pca { get => pca; set => pca = value; }
        public int Xinhua { get => xinhua; set => xinhua = value; }
        public int ASpoly { get => aspoly; set => aspoly = value; }
        public int ARpoly { get => arpoly; set => arpoly = value; }
        public int Hemlock { get => hemlock; set => hemlock = value; }
        public int AsDopant { get => asDopant; set => asDopant = value; }
        public int PhDopant { get => phDopant; set => phDopant = value; }
        public int BDopant { get => bDopant; set => bDopant = value; }
        public DateTime Time { get => time; set => time = value; }
        
    }
}
