using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace M02_ReconnaissanceVIsage_LibrairieClasses
{
    public class ReconnaissanceVisage
    {
        // ** Champs ** //
        private static HttpClient _client = new HttpClient();
        private static Response _result = new Response();

        // ** Propriétés ** //
        public static Response Result { get { return _result; } private set { } }

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public static async Task detectFace(string image_path)
        {
            var request = new MultipartFormDataContent();
            var image_data = File.OpenRead(image_path);
            request.Add(new StreamContent(image_data), "image", System.IO.Path.GetFileName(image_path));
            var output = await _client.PostAsync("http://localhost:80/v1/vision/face", request);
            var jsonString = await output.Content.ReadAsStringAsync();
            _result = JsonConvert.DeserializeObject<Response>(jsonString);
        }

        public static void CadrerVisage(Response p_result, string p_path)
        {
            using (var img = Image.Load(p_path))
            {
                foreach(Face face in p_result.predictions)
                {
                    img.Mutate(ctx =>
                        ctx.Draw(Color.Red, 2.0f, new RectangleF(
                            face.x_min, face.y_min, face.x_max - face.x_min, face.y_max - face.y_min
                        )
                    )
                );
                }
                
                img.Save(p_path);
            }
        }
    }
}
