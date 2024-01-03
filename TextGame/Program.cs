using System;
using System.Collections.Generic;

namespace TextGame2
{
    class Program
    {
        static int Map = 0;
        static bool Purchase = false; //상점에서 아이템 구매중인지 여부
        //static bool Wear = false;


        static Character Player = new Character();

        class Character
        {
            public string Name { get; set; }
            public int LV = 1;
            public string Chad = "전사";
            public int Attack = 10;
            public int Defense = 5;
            public int HP = 100;
            public int Gold = 1500;
            //플레이어가 가지고 있는 아이템 인벤토리에서 사용
            public List<item> haveitem1 = new List<item>();  //방어구
            public List<item> haveitem2 = new List<item>();  //무구

            //추가 공방 설정
            public int PlusAttack = 0;
            public int PlusDefense = 0;

            //나중에 던전 들어갈때 위의 변수를 이용한 함수 만들예정


        }




        class item  //방어구 아이템
        {
            public string Name;
            public int Plusstat;
            public string Explanation; //아이템 설명
            public int Price;
            public bool Have;  //자동으로 false
            public bool Setting;  //장착여부

        }



        //아이템 생성------------------------------------


        static List<item> Armors = new List<item> { };
        static List<item> Weapons = new List<item>();


        static void Main(string[] args)
        {


            CreateItem1(Armors);
            CreateItem2(Weapons);

            //---------------------------------------------
            Console.WriteLine("당신의 이름을 알려주세요.");


            Player.Name = Console.ReadLine();  //캐릭터 이름까지 설정

            Console.Clear(); //이전 내용 지우기
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            StartMap();

            while (true) // 조건 수정
            {

                Console.Clear(); //이전 내용 지우기
                switch (Map)
                {
                    case 0:  //시작마을
                        StartMap();
                        break;

                    case 1: //상태보기
                        State(Player);

                        break;
                    case 2: //인벤토리
                        Inventory();
                        break;
                    case 3: //상점
                        Store();
                        break;

                    default:
                        break;
                }



            }



        }



        // ----------------------------------------------- 함수
        static void StartMap()
        {

            Console.WriteLine();
            Console.WriteLine("============================");
            Console.WriteLine("          활동 선택 ");
            Console.WriteLine("============================");


            Console.ForegroundColor = ConsoleColor.Yellow; //글자 색 변경

            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");

            Console.ResetColor();//  색상 리셋

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            Exception();
        }




        static void State(Character character)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. 상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Console.WriteLine("[ " + Player.Name + " ]");
            Console.WriteLine();

            Console.Write("Level :   " + "\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(character.LV);
            Console.ResetColor();


            Console.WriteLine("\t" + "\t" + "Chad" + "\t" + " ( 전사 )");

            Console.Write("공격력 : " + "\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(character.Attack);
            if(Player.PlusAttack != 0) Console.WriteLine("\t" + "(+" + Player.PlusAttack + ")");
            else Console.WriteLine();
            Console.ResetColor();
            

            Console.Write("방어력 : " + "\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(character.Defense);
            if (Player.PlusAttack != 0) Console.WriteLine("\t" + "(+" + Player.PlusDefense + ")");
            else Console.WriteLine();
            Console.ResetColor();

            Console.Write("체력 :    " + "\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(character.HP);
            Console.ResetColor();

            Console.Write("Gold :    " + "\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(character.Gold);
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("0. 나가기");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");


            //-----------------------------입력
            if (int.Parse(Console.ReadLine()) == 0)
            {
                Map = 0;
            }
            else
            {
                Fail();
                State(character);
            }

        }


        static void Inventory()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            foreach (var item in Player.haveitem1)  //방어구 반복
            {
                if(!item.Setting) //장착이 아닐경우
                {
                    Console.WriteLine("- " + "   " + item.Name + "\t |  방어력  " +
                           item.Plusstat + "  |" + "\t" + item.Explanation);
                }
                else //장착일 경우
                {
                    Console.Write("- [");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("E");
                    Console.ResetColor();
                    Console.Write("]    ");
                    Console.WriteLine("   " + item.Name + "\t |  방어력  " + 
                        item.Plusstat + "  |" + "\t" + item.Explanation);

                }
            }

            foreach (var item in Player.haveitem2)
            {
                if (!item.Setting) //장착이 아닐경우
                {
                    Console.WriteLine("- " + "   " + item.Name + "\t |  방어력  " +
                           item.Plusstat + "  |" + "\t" + item.Explanation);
                }
                else //장착일 경우
                {
                    Console.Write("- [");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("E");
                    Console.ResetColor();
                    Console.Write("]    ");
                    Console.WriteLine("   " + item.Name + "\t |  공격력  " +
                        item.Plusstat + "  |" + "\t" + item.Explanation);

                   
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");





            //-----------------------------------입력

            string userInput = Console.ReadLine();
            if (userInput == "0")
            {
                Map = 0;
            }
            else if (userInput == "1")
            {
                Console.Clear();
                Mounting();
            }
            else
            {
                Fail();
                Inventory();
            }
        }


        static void Mounting()  //장착관리
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리 - 장착관리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();


            Console.WriteLine("[아이템 목록]");


            //화면 배치 -----------------
            int i = 1;
            List<item> Foritem = new List<item>(); //장착 하기를 위해

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Player.haveitem1)  //방어구 반복
            {
                Foritem.Add(item);
                if (!item.Setting) //장착이 아닐경우
                {

                    Console.WriteLine("- " + i  + "   " + item.Name + "\t |  방어력  " +
                           item.Plusstat + "  |" + "\t" + item.Explanation);
                }
                else //장착일 경우
                {

                    Console.WriteLine("- " + i + " [E]    " + item.Name + "\t |  방어력  " +
                        item.Plusstat + "  |" + "\t" + item.Explanation);

                }

                
            }

            foreach (var item in Player.haveitem2)
            {
                Foritem.Add(item);
                if (!item.Setting) //장착이 아닐경우
                {
                    Console.WriteLine("- " + i + "   " + item.Name + "\t |  방어력  " +
                           item.Plusstat + "  |" + "\t" + item.Explanation);
                }
                else //장착일 경우
                {
                    Console.WriteLine("- " + i + " [E]    " + item.Name + "\t |  공격력  " +
                        item.Plusstat + "  |" + "\t" + item.Explanation);

                }
            }
            Console.ResetColor();


            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            //-----------------------------------------


            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 0)
            {
                Map = 0;
            }
            else if (Foritem[userInput-1] == null) //존재 하지 않을 경우
            {
                Fail();
                Mounting();
            }
            else if (Foritem[userInput - 1].Setting) // 장착중일경우
            {
                //장착해제
                //플레이어 추가 공방어력 삭제
                foreach (var item in Player.haveitem1) 
                {
                    if (Foritem[userInput - 1].Name == item.Name)
                    {
                        item.Setting = false;

                        Player.PlusDefense -= item.Plusstat; //추가 스테이터스 삭제
                    }
                }
                foreach (var item in Player.haveitem2)
                {
                    if (Foritem[userInput - 1].Name == item.Name)
                    {
                        item.Setting = false;

                        Player.PlusDefense -= item.Plusstat; //추가 스테이터스 삭제
                    }
                }


                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("***장착이 해제되었습니다***");
                Console.WriteLine("***장착이 해제되었습니다***");
                Console.WriteLine("***장착이 해제되었습니다***");
                Console.ResetColor();

                Console.WriteLine();

                Mounting();
            }
            else if (!Foritem[userInput - 1].Setting)// 장착중이 아닐경우
            {
                foreach (var item in Player.haveitem1) //이름을 찾아 장착으로 바꾸기 그리고 공격력 증가
                {
                    if(Foritem[userInput - 1].Name == item.Name)
                    {
                        item.Setting = true;

                        Player.PlusDefense += item.Plusstat; //추가 스테이터스
                    }
                }
                foreach (var item in Player.haveitem2)
                {
                    if (Foritem[userInput - 1].Name == item.Name)
                    {
                        item.Setting = true;
                        Player.PlusAttack += item.Plusstat; //추가 스테이터스
                    }
                }

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("***장착 되었습니다***");
                Console.WriteLine("***장착 되었습니다***");
                Console.WriteLine("***장착 되었습니다***");
                Console.ResetColor();

                Console.WriteLine();

                Mounting();
            }
        }



        static void Store()  //상점
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}  ", Player.Gold);
            Console.ResetColor();
            Console.WriteLine("G");
            Console.WriteLine();


            Console.WriteLine("[아이템 목록]");


            int i = 1;

            List<item> Foritem = new List<item>();  //여기서 한꺼번에 목록 저장 (플레이어에게 보낼 목록)
            foreach (var item in Armors)
            {
                Foritem.Add(item);


                if (Purchase) //구매할 예정일 경우 숫자로 표시
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (!item.Have)//안가지고 있을경우
                    {
                        Console.WriteLine("- " + i + "   " + item.Name + "\t |  방어력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + item.Price);
                    }
                    else
                    {
                        Console.WriteLine("- " + i + "   " + item.Name + "\t |  방어력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + "구매 완료");
                    }

                    i++;
                    Console.ResetColor();
                }
                else
                {
                    if (!item.Have)//안가지고 있을경우
                    {
                        Console.WriteLine("- " + item.Name + "\t |  방어력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + item.Price);
                    }
                    else
                    {
                        Console.WriteLine("- " + item.Name + "\t |  방어력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + "구매 완료");
                    }

                }


            }

            foreach (var item in Weapons)
            {

                Foritem.Add(item);

                if (Purchase) //구매할 예정일 경우 숫자로 표시
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (!item.Have)//안가지고 있을경우
                    {
                        Console.WriteLine("- " + i + "   " + item.Name + "\t |  공격력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + item.Price);
                    }
                    else
                    {
                        Console.WriteLine("- " + i + "   " + item.Name + "\t |  공격력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + "구매 완료");
                    }

                    i++;
                    Console.ResetColor();
                }
                else
                {
                    if (!item.Have)//안가지고 있을경우
                    {
                        Console.WriteLine("- " + item.Name + "\t |  공격력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + item.Price);
                    }
                    else
                    {
                        Console.WriteLine("- " + item.Name + "\t |  공격력  " +
                            item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + "구매 완료");
                    }

                }


            }

            //구매할 예정일경우 해당 함수 다시 호출 및 Purchase true 하셈

            if (!Purchase)
            {
                Console.WriteLine();

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("1. 아이템 판매");
                Console.WriteLine("0. 나가기");

                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");


                string userInput = Console.ReadLine();
                if (userInput == "0") //나가기
                {
                    Map = 0;
                }
                else if (userInput == "1")
                {
                    Purchase = true;
                    Console.Clear();
                    Store();
                }
                else if (userInput =="2")
                {
                    Console.Clear();
                    sale();
                }
                else
                {
                    Fail();
                    Store();
                }
            }
            else if (Purchase)
            {
                Console.WriteLine();
                Console.WriteLine("0. 나가기");

                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 0)
                {
                    Map = 0;
                    Purchase = false;
                }
                else if (Foritem[userInput - 1] == null)//잘못된 숫자
                {
                    Fail();
                    Store();
                }
                else if (!Foritem[userInput - 1].Have) //아직 구매 안했을 경우
                {
                    foreach (var item in Weapons)
                    {
                        if (Foritem[userInput - 1].Name == item.Name)  //이름이 같은 아이템 찾기
                        {
                            if (item.Price <= Player.Gold)  //돈이 된다면
                            {
                                Player.Gold -= item.Price; //플레이어 돈을 깎고
                                item.Have = true;  //갖고 있음 표시로 바꿔줌(구매 완료로 됨
                                Player.haveitem2.Add(item); //플레이어 아이템에 갱신

                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.ResetColor();

                                Console.WriteLine();

                                Store();
                            }
                            else  //돈이 안된다면
                            {
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.ResetColor();

                                Console.WriteLine();

                                Store();
                            }
                        }
                    }

                    foreach (var item in Armors)
                    {
                        if (Foritem[userInput - 1].Name == item.Name)  //이름이 같은 아이템 찾기
                        {
                            if (item.Price <= Player.Gold)  //돈이 된다면
                            {
                                Player.Gold -= item.Price; //플레이어 돈을 깎고
                                item.Have = true;  //갖고 있음 표시로 바꿔줌(구매 완료로 됨
                                Player.haveitem1.Add(item); //플레이어 아이템에 갱신

                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.WriteLine("***구매를 완료했습니다***");
                                Console.ResetColor();

                                Console.WriteLine();

                                Store();
                            }
                            else  //돈이 안된다면
                            {
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.WriteLine("***Gold 가 부족합니다***");
                                Console.ResetColor();

                                Console.WriteLine();

                                Store();
                            }
                        }
                    }
                }
                else if (Foritem[userInput - 1].Have)  //이미 구매한 경우
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("***이미 구매한 아이템입니다***");
                    Console.WriteLine("***이미 구매한 아이템입니다***");
                    Console.WriteLine("***이미 구매한 아이템입니다***");
                    Console.ResetColor();

                    Console.WriteLine();

                    Store();
                }


            }

        }

        static void sale()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 판매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();


            Console.WriteLine("[보유 골드]");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}  ", Player.Gold);
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");




            //화면 배치 -----------------
            int i = 1;
            List<item> Foritem = new List<item>(); //장착 하기를 위해

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in Player.haveitem1)  //방어구 반복
            {
                Foritem.Add(item);

                Console.WriteLine("- " + i + " [E]    " + item.Name + "\t |  방어력  " +
                        item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + discount(item.Price));

                //장착 + 가진것 해제



            }

            foreach (var item in Player.haveitem2)
            {
                Foritem.Add(item);

                Console.WriteLine("- " + i + " [E]    " + item.Name + "\t |  방어력  " +
                        item.Plusstat + "  |" + "\t" + item.Explanation + "\t |" + "\t" + discount(item.Price));

                //장착 + 가진것 해제
            }
            Console.ResetColor();
            //----------------------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int userInput = int.Parse(Console.ReadLine());
            if (userInput == 0)
            {
                Map = 0;
            }
            else if (Foritem[userInput - 1] == null) //존재 하지 않을 경우
            {
                Fail();
                sale();
            }
            else
            {
                int ThisG = discount(Foritem[userInput - 1].Price); 
                if(Player.Gold >= ThisG) //골드가 된다면
                {
                    foreach (var item in Player.haveitem1) //이름을 찾아 장착, 가진것 해제
                    {
                        if (Foritem[userInput - 1].Name == item.Name)
                        {


                            if (item.Setting) //장착이 되있었다면
                            {
                                item.Setting = false;
                            }

                            item.Have = false; //가진것 해제
                            Player.PlusDefense += item.Plusstat;
                        }
                    }
                    foreach (var item in Player.haveitem2)//이름을 찾아 장착, 가진것 해제
                    {
                        if (Foritem[userInput - 1].Name == item.Name)
                        {
                            if (item.Setting) //장착이 되있었다면
                            {
                                item.Setting = false;
                            }

                            item.Have = false; //가진것 해제
                            Player.PlusAttack += item.Plusstat;
                        }
                    }

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("***판매되었습니다***");
                    Console.WriteLine("***판매되었습니다***");
                    Console.WriteLine("***판매되었습니다***");
                    Console.ResetColor();

                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("***골드가 부족합니다***");
                    Console.WriteLine("***골드가 부족합니다***");
                    Console.WriteLine("***골드가 부족합니다***");
                    Console.ResetColor();

                    Console.WriteLine();
                }

                //골드 빼기

                 //85% 빼기


                

                sale();
            }
            

        }



        //아이템 정렬--------------------------------------------------
        static void CreateItem1(List<item> It1) //방어력 아이템 셋팅 함수
        {
            It1.Add(new item { Name = "수련자 갑옷    ", Plusstat = 5, Explanation = "수련에 도움을 주는 갑옷입니다.    ", Price = 1000 });
            It1.Add(new item { Name = "무쇠갑옷       ", Plusstat = 9, Explanation = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 2200 });
            It1.Add(new item { Name = "스파르타의 갑옷", Plusstat = 15, Explanation = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 3500 });
            It1.Add(new item { Name = "응징갑옷       ", Plusstat = 25, Explanation = "응징의 가호로 이루어진 갑옷입니다.", Price = 4300 });
            It1.Add(new item { Name = "죽어가는 개발자의 옷", Plusstat = 45, Explanation = "제 4의 벽을 넘은 힘의 천으로 만들어졌습니다", Price = 6500 });


        }

        static void CreateItem2(List<item> It2) //공격력 아이템 셋팅 함수
        {
            It2.Add(new item { Name = "낡은 검        ", Plusstat = 2, Explanation = "쉽게 볼 수 있는 낡은 검입니다.     ", Price = 600 });
            It2.Add(new item { Name = "청동 도끼      ", Plusstat = 5, Explanation = "어디선가 사용됐던 거 같은 도끼입니다.", Price = 1500 });
            It2.Add(new item { Name = "스파르타의 창  ", Plusstat = 7, Explanation = "스파르타의 전사들이 사용했다는 전설의 창입니다.", Price = 2700 });
            It2.Add(new item { Name = "응징 건틀렛    ", Plusstat = 18, Explanation = "응징의 힘이 내려지는 낯입니다.", Price = 3800 });
            It2.Add(new item { Name = "고뇌하는 개발자의 낯", Plusstat = 40, Explanation = "제 4의 벽을 넘은 소재의 낯입니다.", Price = 6200 });

        }


        //----------------------------------------------


        static bool Exception() //예외처리
        {

            if (int.TryParse(Console.ReadLine(), out Map))
            {
                return true;
            }
            else
            {

                Fail();
                return false;
            }

        }

        static void Fail()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("***잘못된 입력입니다***");
            Console.WriteLine("***잘못된 입력입니다***");
            Console.WriteLine("***잘못된 입력입니다***");
            Console.ResetColor();

            Console.WriteLine();
        }

        static int discount(int a)
        {
            float b = a * 0.85f;


            return (int)b;

        }
    }
}

