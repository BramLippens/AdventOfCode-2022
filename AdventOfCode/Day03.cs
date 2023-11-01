namespace AdventOfCode
{
    public class Day03 : BaseDay
    {
        private readonly string _input;

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
        }
        public override ValueTask<string> Solve_1()
        {
            var lines = _input.Split('\n');
            var sum = 0;
            foreach (var item in lines)
            { 
                var compartment_one = item.ToCharArray().Take(item.Length / 2).ToArray();
                var compartment_two = item.ToCharArray().Skip(item.Length / 2).ToArray();

                var same = compartment_one.Intersect(compartment_two).First();
                if (char.IsUpper(same))
                {
                    sum += same - 64 + 26;
                }
                else
                {
                    sum += same - 96;
                }
            }

            return new($"{sum}");
        }
        public override ValueTask<string> Solve_2()
        {
            var lines = _input.Split('\n');
            var sum = 0;
            var counter = 0;
            char[][] group = new char[3][];
            foreach (var item in lines)
            {
                group[counter % 3] = item.ToCharArray();
                if (counter % 3 == 2)
                {
                    var temp = group[0].Intersect(group[1]).ToList();
                    var same = temp.Intersect(group[2]).First();

                    if (Char.IsUpper(same))
                    {
                        sum += same - 64 + 26;
                    }
                    else
                    {
                        sum += same - 96;
                    }
                }
                counter++;
            }
            return new($"{sum}");
        }
    }
}
