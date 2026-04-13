public interface IRng
{
    void Init(int seed);
    float Value();
    int Range(int min, int max);
}