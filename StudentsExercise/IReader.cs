namespace StudentsExercise;

public interface IReader
{
    IEnumerable<Result> Read(string fileInput);
}