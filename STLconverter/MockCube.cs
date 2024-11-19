namespace STLconverter
{
    public static class MockCube
    {
        private static readonly List<StlPoint> Normals =
        [
            new(0, 0, 1),
            new(0, 0, 1),
            new(0, -1, 0),
            new(0, -1, 0),
            new(-1, 0, 0),
            new(-1, 0, 0),
            new(0, 0, -1),
            new(0, 0, -1),
            new(1, 0, 0),
            new(1, 0, 0),
            new(0, 1, 0),
            new(0, 1, 0)
        ];

        private static readonly List<StlPoint> Verticies =
            [
            new(1,1,1),
            new(-1,1,1),
            new(-1,-1,1),

            new(1,1,1),
            new(-1,-1,1),
            new(1,-1,1),

            new(1,-1,-1),
            new(1,-1,1),
            new(-1,-1,1),

            new(1,-1,-1),
            new(-1,-1,1),
            new(-1,-1,-1),

            new(-1,-1,-1),
            new(-1,-1,1),
            new(-1,1,1),

            new(-1,-1,-1),
            new(-1,1,1),
            new(-1,1,-1),

            new(-1,1,-1),
            new(1,1,-1),
            new(1,-1,-1),
            
            new(-1,1,-1),
            new(1,-1,-1),
            new(-1,-1,-1),

            new(1,1,-1),
            new(1,1,1),
            new(1,-1,1),

            new(1,1,-1),
            new(1,-1,1),
            new(1,-1,-1),

            new(-1,1,-1),
            new(-1,1,1),
            new(1,1,1),

            new(-1,1,-1),
            new(1,1,1),
            new(1,1,-1)
            ];

        public static IEnumerable<Facet> WriteFacets()
        {
            var cube = new List<Facet>();

            for(int i = 0; i< Normals.Count; i++)
            {
                var ver = new List<StlPoint>
                {
                    Verticies[i * 3],
                    Verticies[(i * 3) + 1],
                    Verticies[(i * 3) + 2]
                };

                cube.Add(new Facet(Normals[i], ver));
            }

            return cube;
        }
    }
}
