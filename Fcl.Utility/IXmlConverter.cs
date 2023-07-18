
namespace Fcl.Utility
{
    public interface IXmlConverter
    {
        /// <summary>
        /// xml to objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeName"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        IEnumerable<T> ToObjects<T>(string nodeName, string xml) where T : class, new();

        /// <summary>
        /// objects to xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeName"></param>
        /// <param name="objs"></param>
        /// <returns></returns>
        string ToXml<T>(string nodeName, IEnumerable<T> objs) where T : class;
    }
}
