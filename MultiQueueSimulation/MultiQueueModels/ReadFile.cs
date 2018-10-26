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
        
       
        public struct Inputs
        {
            public int NumberOfServers;
            public int StoppingCriterea;
            public int StoppingNumber;
            public int SelectionMethod;
            public List<Server> ServersList;
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
                            
                            List<TimeDistribution> tlist = new List<TimeDistribution>();
                            for (int i = 0; i < 4; i++)
                            {
                                TimeDistribution t = new TimeDistribution();
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
                           
                           
                            Server S = new Server();
                            List<Server> Servers = new List<Server>();

                            for (int i = 0; i < initialNumberOfServers; i++)
                            {
                                List<TimeDistribution> tlist = new List<TimeDistribution>();

                                for (int j = 0; j < 4; j++)
                                {
                                     TimeDistribution t = new TimeDistribution();
                                    string tmp = reader.ReadLine();
                                    string[] arr = tmp.Split(',');
                                    t.Time = int.Parse(arr[0]);
                                    t.Probability = decimal.Parse(arr[1]);
                                    tlist.Add(t);

                                }
                                S.ID = i + 1;
                                S.TimeDistribution =  tlist;
                                Servers.Add(S);
                               
                                reader.ReadLine();
                                reader.ReadLine();

                            }
                            Input.ServersList = Servers;
                        }
                        break;
                }
            }
        }
    }
}
