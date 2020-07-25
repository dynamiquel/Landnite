namespace LauncherTest1
{
    public class Language
    {
        public static Language instance;
        public char language = 'e';

        public void Initialise()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }
}
