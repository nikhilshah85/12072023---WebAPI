namespace Httpclient_api_calls.Models
{
    public class PostDetails
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string body { get; set; }
        public string title { get; set; }

        List<PostDetails> postdata = new List<PostDetails>();

        public List<PostDetails> GetPostDataFromJSONPlaceHolder()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new HttpClient();
            //set the client to make a call in data format, i,e the format of data which is coming
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var call = client.GetAsync(url).Result;

            if (call.IsSuccessStatusCode)
            {
                var data = call.Content.ReadAsAsync<List<PostDetails>>();
                data.Wait();
                postdata = data.Result;                

            }
            else
            {
                throw new Exception("Could not load data please contact Admin");
            }
            return postdata;
        }
    }
}
