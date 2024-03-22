namespace StudentsExercise;

public class Reader2 : IReader
{
    public IEnumerable<Result> Read(string fileInput)
    {
        var results = new List<Result>();
        var input = "../../../" + fileInput;

        var lines = File.ReadLines(input);

        foreach (var line in lines)
        {
            var data = line.Split(',');
            if (data.Length != 3)
            {
                continue;
                // Should throw an error or something.
            }

            results.Add(new Result
            {
                Name = data[2],
                PhoneNumber = data[0],
                Age = int.Parse(data[1])
            });
        }

        return results;
    }
}