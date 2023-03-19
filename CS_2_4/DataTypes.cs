using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2_4
{
    // пафосно назвал файлик, а тип данных только 1 потому что мне лень разбивать дальше
    public class Note
    {
        public int id { get; set; } = 0;
        public string name { get; set; }
        public string type { get; set; }
        public bool isPos { get; set; }
        private double _count;
        public double count
        {
            get { return _count; }
            set { _count = value; isPos = value >= 0; }
        }
        public DateTime date;
        public Note(int id, string name, string type, double count, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.count = count;
            this.date = date;
        }
    }
}
