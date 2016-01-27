using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace PhotoArt.Services
{
    public class FileSystemService
    {
        public void Save(Task<byte[]> task, string path)
        {
            task.ContinueWith(async (t) =>
                    {
                        var filePath = HostingEnvironment.MapPath("~/" + path);
                        //// TODO: file can already exist
                        var fileInfo = new FileInfo(filePath);
                        fileInfo.Directory.Create();
                        using (var fileWriter = new FileStream(filePath, FileMode.CreateNew))
                        {
                            await fileWriter.WriteAsync(t.Result, 0, t.Result.Length);
                        }
                    });
        }
    }
}
