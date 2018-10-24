using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiQueueModels
{
    class ReadFile
    {

        struct InterarrivalDistribution
        {
            public List<TimeDistribution> interdist;
        }


        struct ServiceDistribution
        {
            public int servernum;
            public List<TimeDistribution> servicedist;
        }

        struct inputs
        {
            public int numberofservers;
            public int stoppingcriterea;
            public int stoppingnumber;
            public int selectionmethod;
            public InterarrivalDistribution inter;
            public List<ServiceDistribution> service;




        }
        

        public void read(string path)
        {
            //for testing put the  path of testcase1.txt and debug to see the variables
            inputs inp;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            int initialnumberofservers = 0;
            string var;
            while (!reader.EndOfStream)
            {
                var = reader.ReadLine();
                switch (var)
                {

                    case "NumberOfServers":
                        {
                            inp.numberofservers = int.Parse(reader.ReadLine());
                            initialnumberofservers = inp.numberofservers;
                        }
                        break;

                    case "StoppingNumber": { inp.stoppingnumber = int.Parse(reader.ReadLine()); } break;

                    case "StoppingCriteria": { inp.stoppingcriterea = int.Parse(reader.ReadLine()); } break;

                    case "SelectionMethod": { inp.stoppingcriterea = int.Parse(reader.ReadLine()); } break;

                    case "InterarrivalDistribution":
                        {
                            TimeDistribution t = new TimeDistribution();
                            List<TimeDistribution> tlist = new List<TimeDistribution>();
                            for (int i = 0; i < 4; i++)
                            {
                                string tmp = reader.ReadLine();
                                string[] arr = tmp.Split(',');
                                t.Time = int.Parse(arr[0]);
                                t.Probability = decimal.Parse(arr[1]);
                                tlist.Add(t);

                            }
                            inp.inter.interdist = tlist;

                        }
                        break;

                    case "ServiceDistribution_Server1":
                        {
                            TimeDistribution t = new TimeDistribution();
                            List<TimeDistribution> tlist = new List<TimeDistribution>();
                            ServiceDistribution dist;
                            List<ServiceDistribution> service = new List<ServiceDistribution>();

                            for (int i = 0; i < initialnumberofservers; i++)
                            {

                                for (int j = 0; j < 4; j++)
                                {
                                    string tmp = reader.ReadLine();
                                    string[] arr = tmp.Split(',');
                                    t.Time = int.Parse(arr[0]);
                                    t.Probability = decimal.Parse(arr[1]);
                                    tlist.Add(t);

                                }
                                dist.servernum = i + 1;
                                dist.servicedist = tlist;
                                service.Add(dist);
                                reader.ReadLine();

                            }
                            inp.service = service;





                        }
                        break;


                }


            }
        }
    }
}
