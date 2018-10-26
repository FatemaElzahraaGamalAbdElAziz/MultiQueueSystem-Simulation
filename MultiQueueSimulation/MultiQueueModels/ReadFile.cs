using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiQueueModels
{
    public class ReadFile
    {

        
        public List<TimeDistribution> InterarrivalDistribution;
        
        public struct ServiceDistribution
        {
            public int servernum;
            public List<TimeDistribution> servicedist;
        }
        public struct Inputs
        {
            public int NumberOfServers;
            public int StoppingCriterea;
            public int StoppingNumber;
            public int SelectionMethod;
            public List<ServiceDistribution> service;
        }
        public Inputs Input;
        public void Read(string path)
        {
            //for testing put the  path of testcase1.txt and debug to see the variables
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            int initialNumberOfServers = 0;
            string var;
            while (!reader.EndOfStream)
            {
                var = reader.ReadLine();
                switch (var)
                {

                    case "NumberOfServers":
                        {
                            Input.NumberOfServers = int.Parse(reader.ReadLine());
                            initialNumberOfServers = Input.NumberOfServers;
                        }
                        break;

                    case "StoppingNumber": { Input.StoppingNumber = int.Parse(reader.ReadLine()); } break;

                    case "StoppingCriteria": { Input.StoppingCriterea = int.Parse(reader.ReadLine()); } break;

                    case "SelectionMethod": { Input.StoppingCriterea = int.Parse(reader.ReadLine()); } break;

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
                            InterarrivalDistribution = tlist;

                        }
                        break;

                    case "ServiceDistribution_Server1":
                        {
                            TimeDistribution t = new TimeDistribution();
                            List<TimeDistribution> tlist = new List<TimeDistribution>();
                            ServiceDistribution dist;
                            List<ServiceDistribution> service = new List<ServiceDistribution>();

                            for (int i = 0; i < initialNumberOfServers; i++)
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
                                reader.ReadLine();

                            }
                            Input.service = service;
                        }
                        break;
                }
            }
        }
    }
}
