using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciPhyLib
{
    class Bearer
    {
        public String state;
        public String access_token;
        public String token_type;
        public Int32 expires_in = 0;
        public DateTime expieredTime;

        public Bearer()
        {
            state = "";
            access_token = "";
            token_type = "";
            expieredTime = DateTime.Now.AddSeconds(-10);
        }
        public Bearer(String response, Logger logger)
        {
            String[] responseData = response.Split(new char[] { '#', '&' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in responseData)
            {

                String[] responseDataPair = item.Split(new char[] { '=' });
                switch (responseDataPair[0])
                {
                    case "state":
                        state = responseDataPair[1];
                        break;
                    case "access_token":
                        access_token = responseDataPair[1];
                        break;
                    case "token_type":
                        token_type = responseDataPair[1];
                        break;
                    case "expires_in":
                        expires_in = Int32.Parse(responseDataPair[1]);
                        expieredTime = DateTime.Now.AddSeconds(expires_in);
                        break;
                    default:
                        break;
                }
            }
            if (token_type != "Bearer")
            {
                expires_in = 0;
                logger.WriteLogLine("Wrong token type: " + token_type);
            }
        }
    }
}
