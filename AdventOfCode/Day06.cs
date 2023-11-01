namespace AdventOfCode
{
    public class Day06 : BaseDay
    {
        private readonly string _input;

        public Day06()
        {
            _input = File.ReadAllText(InputFilePath);
        }
        public override ValueTask<string> Solve_1()
        {
            var marker = new char[4];
            var buffer = _input.ToCharArray();
            for(int i = 0; i < marker.Length - 1; i++)
            {
                marker[i] = buffer[i];
            }
            for(int i = 3; i < buffer.Length; i++)
            {
                marker[i % 4] = buffer[i];
                if(marker.Distinct().Count() == 4)
                {
                    return new($"{i + 1}");
                }
            }
            return new($"Not Found!");
        }

        public override ValueTask<string> Solve_2()
        {
            var lengthMarker = 14;
            var marker = new char[lengthMarker];
            var buffer = _input.ToCharArray();
            for (int i = 0; i < lengthMarker - 1; i++)
            {
                marker[i] = buffer[i];
            }
            for (int i = lengthMarker - 1; i < buffer.Length; i++)
            {
                marker[i % lengthMarker] = buffer[i];
                if (marker.Distinct().Count() == lengthMarker)
                {
                    return new($"{i + 1}");
                }
            }
            return new($"Not Found!");
        }
    }
}