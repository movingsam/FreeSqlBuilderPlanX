using System.Linq;

namespace FreeSqlBuilderPlanX.Infrastructure.Utils
{
    /// <summary>
    /// 图片帮助类
    /// </summary>
    public static class Image
    {
        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsImages(string fileName)
        {
            string[] imagesTypes = new[] { ".jpg", ".png", ".gif", ".jpeg", ".bmp" };
            return imagesTypes.Any(fileName.Contains);
        }
    }
}
