using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }

        public static string GenerateRandomInt(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 9)));
            }
            
            return builder.ToString();
        }

        public static string GenerateRandomDay()
        {
            StringBuilder builder = new StringBuilder();

            int nextdata = Convert.ToInt32(rnd.NextDouble());
            if (nextdata == 0)
            { builder.Append("-"); }
            else
            {
                builder.Append(Convert.ToChar(48 + nextdata * 9)); 

                if (Convert.ToInt32(builder.ToString()) == 3)
                { builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 1))); }
                else
                {
                    if (Convert.ToInt32(builder.ToString()) == 1 || Convert.ToInt32(builder.ToString()) == 2)
                    { builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 9))); }
                }
            }
            return builder.ToString();
        }

        public static string GenerateRandomMonth()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 9)));
            if (Convert.ToInt32(builder.ToString()) == 1)
            { builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 2))); }

            return builder.ToString();
        }

        public static string GenerateRandomYear()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                builder.Append(Convert.ToChar(48 + Convert.ToInt32(rnd.NextDouble() * 9))); 
            }

            return builder.ToString();
        }
    }
}
