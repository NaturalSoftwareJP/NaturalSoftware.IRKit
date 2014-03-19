using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaturalSoftware.IRKit
{
    public class IRKitProvider
    {
        HttpClient client = new HttpClient();

        string name;

        public IRKitProvider(string name)
        {
            this.name = name;
        }

        public async Task<string> GetMessages()
        {
            //string uri = string.Format( @"http://{0}.local/messages", name );
            string uri = string.Format( @"http://{0}/messages", name );
            var res = await client.GetAsync( uri );
            return await res.Content.ReadAsStringAsync();
        }

        public async Task PostMessages( string messages )
        {
            //string uri = string.Format( @"http://{0}.local/messages", name );
            string uri = string.Format( @"http://{0}/messages", name );
            var res = await client.PostAsync( uri, new ByteArrayContent( Encoding.UTF8.GetBytes( messages ) ) );
        }

        public async Task<string> PostKeys()
        {
            //string uri = string.Format( @"http://{0}.local/messages", name );
            string uri = string.Format( @"http://{0}/keys", name );
            var res = await client.PostAsync( uri, null );
            return await res.Content.ReadAsStringAsync();
        }
    }
}
