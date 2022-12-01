using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOG_TO_SERVER_TEST.Model
{
    public class Tractor
    {
        string id;
        string name;

        public Tractor()
        {

        }

        public Tractor(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }   
}
