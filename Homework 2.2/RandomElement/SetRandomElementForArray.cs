namespace RandomElement
{
    public static class SetRandomElementForArray
    {
        public static int[] SetRandomElement(this int []array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(int.MinValue, int.MaxValue);
            }
            return array;
        }
    }
}
