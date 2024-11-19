using System.Formats.Tar;
using System.Text;

namespace STLconverter
{
    public class STLwriter
    {
        public void CreateSTLFile()
        {
            var cube = MockCube.WriteFacets();

            var stlFile = new StringBuilder();
            stlFile.AppendLine(Constants.StartFile);

            foreach(var facet in cube)
            {
                stlFile.AppendLine($"{Constants.StartFacet} {facet.normal.x} {facet.normal.y} {facet.normal.z}");
                
                stlFile.AppendLine(Constants.OuterLoop);
                stlFile.AppendLine($"{Constants.Vertex} {facet.vertices[0].x} {facet.vertices[0].y} {facet.vertices[0].z}");
                stlFile.AppendLine($"{Constants.Vertex} {facet.vertices[1].x} {facet.vertices[1].y} {facet.vertices[1].z}");
                stlFile.AppendLine($"{Constants.Vertex} {facet.vertices[2].x} {facet.vertices[2].y} {facet.vertices[2].z}");
                stlFile.AppendLine(Constants.EndLoop);
                
                stlFile.AppendLine(Constants.EndFacet);
            }
      
            stlFile.AppendLine(Constants.EndFile);

            File.AppendAllLines(Path.Combine("", "myCube.stl"), [stlFile.ToString()]);
        }
    }

    public record StlPoint(decimal x, decimal y, decimal z);

    public record Solid(IEnumerable<Facet> Facets);
    public class Facet
    {
        public StlPoint normal;

        public List<StlPoint> vertices;

        public Facet(StlPoint facet, IEnumerable<StlPoint> vertices)
        {
            if (vertices.Count() != 3) return;

            this.normal = facet;
            this.vertices = vertices.ToList();
        }
    }
}
