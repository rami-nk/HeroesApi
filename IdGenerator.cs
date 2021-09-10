namespace HeroesApi
{
    public static class IdGenerator
    {
        private static long _current = 1;

        public static long NewId()
        {
            long ret = _current;
            _current++;
            return ret;
        }
    }
}