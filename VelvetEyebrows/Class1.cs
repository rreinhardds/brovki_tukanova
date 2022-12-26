using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetEyebrows.Models;

namespace VelvetEyebrows
{
    internal class Class1
    {
        public class Session
        {
            private Session()
            {
                context = new SalonContext();
            }

            private static Session? instance;
            public static Session Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Session();
                    }
                    return instance;
                }
            }

            private SalonContext context;
            public SalonContext Context => context;
        }
    }
}
