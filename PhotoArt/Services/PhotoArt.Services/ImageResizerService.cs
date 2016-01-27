namespace PhotoArt.Services
{
    using ImageProcessor;
    using ImageProcessor.Imaging;
    using ImageProcessor.Imaging.Formats;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImageResizeService
    {
        public Task<byte[]> Resize(byte[] originalImage, int width)
        {
            return Task.Run(() =>
            {
                using (var originalImageStream = new MemoryStream(originalImage))
                {
                    using (var resultImage = new MemoryStream())
                    {
                        using (var imageFactory = new ImageFactory())
                        {
                            var createdImage = imageFactory
                                .Load(originalImageStream);

                            if (createdImage.Image.Width > width)
                            {
                                createdImage = createdImage
                                    .Resize(new ResizeLayer(new Size(width, 0), ResizeMode.Max));
                            }

                            createdImage
                                .Format(new JpegFormat { Quality = 60 })
                                .Save(resultImage);
                        }

                        return resultImage.GetBuffer();
                    }
                }
            });
        }
    }
}
