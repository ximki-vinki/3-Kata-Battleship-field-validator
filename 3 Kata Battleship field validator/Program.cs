using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace _3_Kata_Battleship_field_validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        public class BattleshipField
        {


            public static bool ValidateBattlefield(int[,] field)
            {
                bool angel = BattleshipField.CheckAngle(field);
                BattleshipField.CountShip(field);
                int count1 = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {

                        switch (field[i, j])
                        {
                            case 0: break;
                            case 1: count1++; break;
                            case 2: count2++; break;
                            case 3: count3++; break;
                            case 4: count4++; break;
                            default: return false;
                        }
                    }
                }
                if (count1 == 4 && count2 == 3 && count3 == 2 && count4 == 1 && angel) return true;
                return false;


            }
            public static void CountShip(int[,] field)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (field[i, j] == 1)
                        {
                            LenghtShip(field, i, j);
                        }

                    }
                }
            }
            public static void LenghtShip(int[,] field, int i, int j)
            {
                while (field[i, j + 1] == 1 && j < 9)
                {
                    field[i, j + 1] = field[i, j] + 1;
                    field[i, j] = 0;
                    j++;
                }
                j = j - field[i, j] + 1;
                while (field[i + 1, j] == 1 && j < 9)
                {
                    field[i + 1, j] = field[i, j] + 1;
                    field[i, j] = 0;
                    i++;
                }

            }
            public static bool CheckAngle(int[,] field)
            {
                for (int i = 6; i < 10; i++) //1
                {
                    for (int j = 3; j < 10; j++)//0
                    {
                        switch (j)
                        {
                            case 0:
                                if (field[i, j] == 1 && field[i - 1, j + 1] == 1) return false;
                                break;

                            case 9:
                                if (j == 9 && field[i, j] == 1 && field[i - 1, j - 1] == 1) return false;
                                break;
                            default:
                                if (field[i, j] == 1 && (field[i - 1, j + 1] == 1 || field[i - 1, j - 1] == 1)) return false;
                                break;

                        }
                    }
                }
                return true;
            }


        }
    }


}


