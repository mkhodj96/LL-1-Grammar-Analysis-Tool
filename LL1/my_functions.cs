using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL1
{
   public static class my_functions
    {

        public static string Firstseens = "";
        public static string Followseens = "";
        public static string CheakVisited = "";
        
        public static bool IsLL1 = true;
        public static string GramerText;
        public static char[] Variables;
        public static char[] nonvaribles;
     
        public struct GrammerRow
        {
            public char LeftVariable;
            public string RightPhrase;
        }
        static GrammerRow[] Grammers;
        public static string[] GrammersTemp;

        public static bool onlyVariable(GrammerRow Gr)
        {
            for (int i = 0; i < Gr.RightPhrase.Length; i++)
                if (Isnon_variable(Gr.RightPhrase[i]))
                    return false;
            return true;
        }
        public static bool IsGoTolanda(char variable)
        {
            for (int i = 0; i < Grammers.Length; i++)
                if (Grammers[i].LeftVariable == variable)
                {
                    if (Grammers[i].RightPhrase == "&")
                        return true;
                }
            for (int i = 0; i < Grammers.Length; i++)
                if (Grammers[i].LeftVariable == variable)
                    if (onlyVariable(Grammers[i]))
                    {
                        for (int j = 0; j < Grammers[i].RightPhrase.Length; j++)
                        {
                            if (!IsGoTolanda(Grammers[i].RightPhrase[j]))
                                break;
                            return true;
                        }
                    }
            return false;
        }


        public static void is_it_LL1()/////  core 
        {
             IsLL1 = true;
            string s2 = "";

            for (int i = 0; i < Variables.Length; i++)
            {
                
                if (IsLL1 == true)
                {
                    s2 = "";
                    for (int u = 0; u < Grammers.Length; u++)
                    {
                        if (Grammers[u].LeftVariable == Variables[i])
                        {

                            if (Isnon_variable(Grammers[u].RightPhrase[0]))
                            {
                                s2 += Grammers[u].RightPhrase[0];
                            }
                            else
                            {
                                s2 += Get_First(Grammers[u].RightPhrase[0]);
                            }
                        }

                    }

                    for (int k = 0; k < nonvaribles.Length; k++)
                    {
                        int r1 = s2.IndexOf(nonvaribles[k]);
                        int r2 = s2.LastIndexOf(nonvaribles[k]);
                        if (r1 != r2)
                        {
                            IsLL1 = false;
                            break;
                        }
                    }
                }

            }

            if (IsLL1 == true)
            {
                for (int i = 0; i < Variables.Length; i++)
                {
                    string temp2 = Get_First(Variables[i]);
                    Followseens = "";
                    string temp31 = Get_Follow(Variables[i]);

                    if (ExistChar('&', temp2))
                    {
                        for (int j = 0; j < temp2.Length; j++)
                        {

                            for (int k = 0; k < temp31.Length; k++)
                            {
                                if (temp31[k] == temp2[j])
                                {
                                    IsLL1 = false;
                                    break;
                                }
                            }

                        }
                    }
                }

            }
            if(IsLL1==true)
            {
                for (int u = 0; u < Grammers.Length; u++)

                {
                    if (Isnon_variable(Grammers[u].RightPhrase[0]))
                    {
                        break;
                    }
                    else
                    {
                          for (int i = 0; i < Grammers.Length; i++)
                          {
                              if(Grammers[i].LeftVariable==Grammers[u].RightPhrase[0])
                              {
                                  
                                  if(Grammers[i].RightPhrase[0]==Grammers[u].LeftVariable)
                                  {
                                      IsLL1 = false;
                                      break;
                                  }
                              }
                          }
                    }

                }
            }
        }
                   
                             

 

        public static void GeramerText_InsertTo_GrammersTemp()
        {
            int Counter = 1;
            for (int i = 0; i < GramerText.Length; i++)
                if (GramerText[i] == '\n')
                    Counter++;
            GrammersTemp = new string[Counter];
            int k = 0;
            for (int i = 0; i < GramerText.Length; i++)
            {
                if (GramerText[i] == '\n')
                    k++;
                else
                    GrammersTemp[k] += GramerText[i];
            }

        }
        public static void InsertToStruct()
        {
            Grammers = new GrammerRow[GrammersTemp.Length];
            for (int i = 0; i < GrammersTemp.Length; i++)
            {
                Grammers[i] = new GrammerRow();
                Grammers[i].LeftVariable = GrammersTemp[i][0];
                Grammers[i].RightPhrase = GrammersTemp[i].Remove(0, 3); ;
            }
        }

        public static string delete_space(string input)
        {
            string Ans = "";
            for (int i = 0; i < input.Length; i++)
                if (input[i] != ' ')
                    Ans += input[i];
            return Ans;
        }
        public static string delete_enters(string input)
        {
            string Ans = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0 || i == input.Length - 1)
                    if (input[i] == '\n')
                        continue;
                if (input[i] == '\n')
                    if (input[i + 1] == '\n')
                        continue;
                Ans += input[i];
            }
            if (input[0] == '\n')
                Ans = Ans.Remove(0, 1);
            return Ans;
        }

        public static bool ExistChar(char c, string str)
        {
            for (int i = 0; i < str.Length; i++)
                if (c == str[i])
                    return true;
            return false;
        }

        public static string ClearLanda(string input)
        {
            string Ans = "";
            for (int i = 0; i < input.Length; i++)
                if (input[i] != '&')
                    Ans += input[i];
            return Ans;
        }

        public static string delete_likes(string input)
        {
            string Ans = "";
            for (int i = 0; i < input.Length; i++)
            {
                string temp = input.Remove(0, i + 1);
                if (!ExistChar(input[i], temp))
                    Ans += input[i];
            }
            return Ans;
        }


        public static string Get_First(char InputVariable)
        {
            string Ans = "";
          
            Firstseens += InputVariable;
            for (int i = 0; i < Grammers.Length; i++)
                if (Grammers[i].LeftVariable == InputVariable)
                   
                    if (Isnon_variable(Grammers[i].RightPhrase[0]))
                    {
                        Ans += Grammers[i].RightPhrase[0];
                    
                        
                    }
                    else if (Grammers[i].RightPhrase[0] == '&')
                    {
                        Ans += Grammers[i].RightPhrase[0];
                        break;
                    }
                    else
                    {
                        if (!ExistChar(Grammers[i].RightPhrase[0], Firstseens))
                        {
                            Ans += Get_First(Grammers[i].RightPhrase[0]);
                            if (!IsGoTolanda(Grammers[i].RightPhrase[0]))
                                break;
                        }
                    }
           

            return delete_likes(Ans);
        }


        public static string Get_Follow(char InputVariable)
        {

            string Ans = "$";
            Followseens += InputVariable;
    
            for (int i = 0; i < Grammers.Length; i++)      
                for (int j = 0; j < Grammers[i].RightPhrase.Length; j++)              
                    if (Grammers[i].RightPhrase[j] == InputVariable)   
                    {
                        if (j < Grammers[i].RightPhrase.Length -1)
                        {
                            if (Isnon_variable(Grammers[i].RightPhrase[j + 1]))                           
                                Ans += Grammers[i].RightPhrase[j + 1];
                            else
                            {
                                Ans += Get_First(Grammers[i].RightPhrase[j + 1]); 
                              Firstseens = "";
                                if (IsGoTolanda(Grammers[i].RightPhrase[j + 1]))  
                                {
                                    if (!ExistChar(Grammers[i].LeftVariable, Followseens)) 
                                        Ans += Get_Follow(Grammers[i].LeftVariable);
                                }
                            }
                        }
                        else
                        {


                            if (!ExistChar(Grammers[i].LeftVariable, Followseens))
                                Ans += Get_Follow(Grammers[i].LeftVariable);
                        }
                    }
            return delete_likes(ClearLanda(Ans)); 
        }

       
        public static string ClearDoller(string input)
        {
            string Ans = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '$')
                {
                    Ans += input[i];
                }
            }
            return Ans;
        }


        public static void Get_variable_non_variables(string input)
        {
            input = delete_likes(input);
            int variableConter = 0, non_variablesConter = 0;
            for (int i = 0; i < input.Length; i++)
                if (IsVariable(input[i]))
                    variableConter++;
            for (int i = 0; i < input.Length; i++)
                if (Isnon_variable(input[i]))
                    non_variablesConter++;
            Variables = new char[variableConter];
            nonvaribles = new char[non_variablesConter];
            variableConter = 0;
            non_variablesConter = 0;
            for (int i = 0; i < input.Length; i++)
                if (IsVariable(input[i]))
                    Variables[variableConter++] = input[i];
            for (int i = 0; i < input.Length; i++)
                if (Isnon_variable(input[i]))
                    nonvaribles[non_variablesConter++] = input[i];
        }
        public static bool IsVariable(char input)
        {
            return char.IsUpper(input);
        }
        public static bool Isnon_variable(char input)
        {
            if (char.IsLower(input))
                return true;
            if (char.IsNumber(input))
                return true;
            if (input == ';' || input == ')' || input == '(' || input == '}' || input == '{' || input == '*' || input == '+')
                return true;
            return false;
        }

        public static string ShowFirsts()
        {

            string Ans = "";
            for (int i = 0; i < Variables.Length; i++)
            {
                string temp2 = Get_First(Variables[i]);
                string First = "";
                for (int j = 0; j < temp2.Length; j++)
                {
                    First += temp2[j];
                    if (!((temp2.Length == 1) || (temp2.Length - 1 == j)))
                        First += " - ";
                }
                Ans += "First(" + Variables[i] + ")=< " + First + " >\n";
                Firstseens = "";
            }
            return Ans;
        }
        public static string ShowFollow()
        {
            string Ans = "";

            for (int i = 0; i < Variables.Length; i++)
            {
                Followseens = "";
                string temp2 = Get_Follow(Variables[i]);
                string Follow = "";
                for (int j = 0; j < temp2.Length; j++)
                {
                    Follow += temp2[j];
                    if (!((temp2.Length == 1) || (temp2.Length - 1 == j)))
                        Follow += " - ";
                }
                Ans += "Follow(" + Variables[i] + ")=< " + Follow + " >\n";
            }
            return Ans;
        }

       
       public static void go(string input)
       {
           input = delete_enters(delete_space(input));
           GramerText = input;
           Get_variable_non_variables(GramerText);
           GeramerText_InsertTo_GrammersTemp();
           InsertToStruct();
           is_it_LL1();
            
       }
       

    }
}


