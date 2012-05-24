
using System;
namespace chiase
{
    public class DictionaryOption
    {
        public static bool ConfigAll = true;

        public static int GetLanguage(Language values)
        {
            int result = 1;
            if (values == Language.VietNam)
            {
                result = 1;
            }
            if (values == Language.English)
            {
                result = 2;
            }
            if (values == Language.Chines)
            {
                result = 3;
            }
            if (values == Language.English_VietNam)
            {
                result = 4;
            }
            if (values == Language.VietNam_English)
            {
                result = 5;
            }
            if (values == Language.English_Chines)
            {
                result = 6;
            }
            if (values == Language.Chines_English)
            {
                result = 7;
            }
            if (values == Language.English_VietNam)
            {
                result = 8;
            }
            if (values == Language.VietNam_Chines)
            {
                result = 9;
            }
            return result;
        }

        public static Language GetLanguage(int languageType)
        {
            Language Result = Language.VietNam;
            switch (languageType)
            {
                case 1:
                    return Language.VietNam;

                case 2:
                    return Language.English;

                case 3:
                    return Language.Chines;

                case 4:
                    return Language.English_VietNam;

                case 5:
                    return Language.VietNam_English;

                case 6:
                    return Language.English_Chines;

                case 7:
                    return Language.Chines_English;

                case 8:
                    return Language.Chines_VietNam;

                case 9:
                    return Language.VietNam_Chines;
            }
            return Result;
        }

        public static bool GetWriteType(WriteType isShort)
        {
            return (isShort == WriteType.Short);
        }

        public static WriteType GetWriteType(bool isShort)
        {
            if (isShort)
            {
                return WriteType.Short;
            }
            return WriteType.Full;
        }

        public enum Language
        {
            VietNam,
            English,
            Chines,
            English_VietNam,
            VietNam_English,
            English_Chines,
            Chines_English,
            Chines_VietNam,
            VietNam_Chines
        }

        public enum WriteType
        {
            Short,
            Full
        }
    }

}