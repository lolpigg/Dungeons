using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class
    {
        //lets start ma boizz
        public static void Main(string[] args)
        {
            bool NpcReward = false;
            bool WizardReward = false;
            bool NpcKilled = false;
            bool WizardKill = false;
            bool WizardMoney = false;
            bool SecondQuest = false;
            bool TalkToTrainer = false;
            int WizardHelp = 0;
            bool WizardReject = false;
            bool Strenght = false;
            bool TalkTalk = false;
            bool RewardNPC = false;
            bool IsTalk = false;
            int Heal = 40;
            bool Book = false;
            bool ChestOpen = false;
            int Potion = 0;
            int ArmorDef = 0;
            int LightDef = 5;
            int HeavyDef = 12;
            int Money = 0;
            int Weapon = 0;
            bool BookReject = false;
            int WeaponDmg = 0;
            int WeaponDef = 0;
            int SwordDef = 0;
            int SwordDmg = 15;
            int BowDmg = 12;
            int BowDef = 5;
            int ShieldDmg = 5;
            int ShieldDef = 12;
            string[,] zone = new string[9, 16];
            Zone _proto_zone = new Zone();
            _proto_zone.ZoneId = 1;              // Номер зоны
            bool EnemyDead = false;
            bool TalkToNPC = false;
            int EnemyHp = 50;
            int PlayerHp = 100;
            int EnemyDmg = 15;
            int PlayerDmg = 5 + WeaponDmg;
            var IsFight = true;
            dynamic[] Invenetary = { Money, Weapon };
            Random rnd = new Random();

            //Спавн игрока
            int y = 2, x = 5;
            bool isSolid;
            //Буфер
            int yb = y, xb = x;


            while (true)
            {
                void Room1(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone1(zone, y, x);
                }
                void Room2(string[,] zone, int y, int x)
                {
                    _proto_zone.RenderZone2(zone, y, x);
                }
                isSolid = zone[y, x] == " #" || zone[y, x] == " |" || zone[y, x] == "| "
                       || zone[y, x] == "__" || zone[y, x] == "|_" || zone[y, x] == "_|";

                if (isSolid)
                {
                    y = yb;
                    x = xb;
                }

                if (zone[y, x] == " Ш")
                {
                    y = yb;
                    x = xb;
                    if (ChestOpen == false)
                    {
                        Console.WriteLine("Перед вами сундук. Вы открываете его.");
                        Console.WriteLine("Внутри не было ничего кроме старой пыльной книги под названием Утопия. Вы взяли ее с собой.");
                        ChestOpen = true;
                        Book = true;
                    }
                    else
                    {
                        Console.WriteLine("Вы уже открывали этот сундук. Теперь он пуст.");
                    }
                }
                if (zone[y, x] == " M")
                {
                    y = yb;
                    x = xb;
                    IsTalk = true;
                    if (Book == true && IsTalk == true && BookReject == false)
                    {
                        Console.WriteLine("Здравствуй, приключенец! Проходи, посмотри на мои товары.");
                        Console.WriteLine("Я чую ауру книги у тебя в рюкзаке. Я куплю ее за 300 монет.\nY - Принять N - Отказ");
                        ConsoleKeyInfo BookSell = Console.ReadKey(true);
                        switch (BookSell.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine("Спасибо. Вот твои деньги.");
                                Money = Money + 300;
                                Console.WriteLine($"У вас теперь {Money} монет.");
                                Book = false;
                                IsTalk = false;
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Ну пожалуйста! Давай я дам 340 монет!\n\tY - Принять N - Отказ");
                                ConsoleKeyInfo Torg = Console.ReadKey(true);
                                switch (Torg.Key)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("Ну вот! Так бы сразу! С вами приятно иметь дело.");
                                        Money = Money + 340;
                                        Console.WriteLine($"У вас теперь {Money} монет.");
                                        IsTalk = false;
                                        Book = false;
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Эх, зря вы так, я ведь предложил хорошую цену!");
                                        IsTalk = false;
                                        BookReject = true;
                                        break;
                                }
                                break;
                            default: break;
                        }
                    }
                    if (Book == false && IsTalk == true || Book == true && IsTalk == true && BookReject == true)
                    {
                        Console.WriteLine("Привет! Хочешь что-нибудь купить?");
                        Console.WriteLine($"Ваш баланс - {Money} монет.");
                        Console.WriteLine("Легкие доспехи - 150(A), Тяжелые доспехи - 350(S), Щит - 150(D)");
                        Console.WriteLine("Лук - 100(F), Меч - 80(G), Зелье Исцеления - 30(H)");
                        Console.WriteLine("Выйти - W");
                        ConsoleKeyInfo BuyMenu = Console.ReadKey(true);
                        switch (BuyMenu.Key)
                        {
                            case ConsoleKey.A:
                                if (Money >= 150)
                                {
                                    Money = Money - 150;
                                    Console.WriteLine($"Вы купили Легкие доспехи! У вас осталось {Money} монет.");
                                    ArmorDef = LightDef;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.S:
                                if (Money >= 350)
                                {
                                    Money = Money - 350;
                                    Console.WriteLine($"Вы купили Тяжелые доспехи! У вас осталось {Money} монет.");
                                    ArmorDef = HeavyDef;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.D:
                                if (Money >= 150)
                                {
                                    Money = Money - 150;
                                    Console.WriteLine($"Вы купили Щит! У вас осталось {Money} монет.");
                                    WeaponDef = ShieldDef;
                                    WeaponDmg = ShieldDmg;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.F:
                                if (Money >= 100)
                                {
                                    Money = Money - 100;
                                    Console.WriteLine($"Вы купили Лук! У вас осталось {Money} монет.");
                                    WeaponDef = BowDef;
                                    WeaponDmg = BowDmg;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.G:
                                if (Money >= 80)
                                {
                                    Money = Money - 80;
                                    Console.WriteLine($"Вы купили Меч! У вас осталось {Money} монет.");
                                    WeaponDef = SwordDef;
                                    WeaponDmg = SwordDmg;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.H:
                                if (Money >= 30)
                                {
                                    Money = Money - 30;
                                    Console.WriteLine($"Вы купили Зелье исцеления! У вас осталось {Money} монет.");
                                    Potion++;
                                    IsTalk = false;
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                    IsTalk = false;
                                }
                                break;
                            case ConsoleKey.W:
                                break;
                            default:
                                {
                                    Console.WriteLine("У меня всего 6 ячеек с предметами. Введите номер ячейки.");
                                    break;
                                }
                        }
                    }
                }
                if (zone[y, x] == " ?")
                {
                    y = yb;
                    x = xb;
                    if ((EnemyDead == false) && (TalkToNPC == false))
                    {
                        Console.WriteLine("Здравствуй путник! Меня зовут Витя! Что привело тебя в эти темные и непроглядные пучины подземелья?");
                        Console.WriteLine("Помоги мне убить монстра и я тебя вознагражу! Для начала тебе нужно купить оружие. Держи 80 монет для покупки меча.");
                        Money = Money + 80;
                        Console.WriteLine($"У вас теперь {Money} монет.");
                        TalkToNPC = true;
                        TalkTalk = true;
                    }
                    else if ((EnemyDead == true) && (RewardNPC == false))
                    {
                        Console.WriteLine("Ты убил его! Огромное тебе спасибо. Вот, возьми это в качестве платы.");
                        Console.WriteLine("Вы получили 150 золотых монет!");
                        Money = Money + 150;
                        Console.WriteLine($"У вас теперь {Money} монет.");
                        RewardNPC = true;
                    }
                    else if ((EnemyDead == false) && (TalkToNPC == true))
                    {
                        Console.WriteLine("Прошу, поторопись. Не стоит заставлять монстра ждать, он многое может натворить.");
                    }
                    else if ((EnemyDead == true) && (RewardNPC == true) && SecondQuest == false)
                    {

                        Console.WriteLine("О, мой дорогой друг! Я снова нуждаюсь в твоей помощи. \n Нужно забрать долг у одного человека, сможешь?");
                        Console.WriteLine("Y - Принять задание, N - Я таким не занимаюсь.");
                        ConsoleKeyInfo NpcQuest = Console.ReadKey(true);
                        switch (NpcQuest.Key)
                        {
                            case ConsoleKey.Y:
                                SecondQuest = true;
                                Console.WriteLine("Этот человек - маг. Половина от денег твоя. Удачи!");
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Как пожелаешь, но лучше бы тебе передумать.");
                                break;
                            default:
                                break;
                        }
                    }
                    else if ((EnemyDead == true) && (RewardNPC == true) && SecondQuest == true && WizardMoney == false && WizardKill == false)
                    {
                        Console.WriteLine("Верни мне долг мага.");
                    }
                    else if (WizardMoney == true && WizardKill == false && NpcKilled == false && NpcReward == false)
                    {
                        Console.WriteLine("Молодец! Я в тебе не сомневался! Давай сюда деньги, дам тебе половину.");
                        Console.WriteLine("Y - Дать, N - После того, как убью тебя.");
                        ConsoleKeyInfo WizardMoneyNpc = Console.ReadKey(true);
                        switch (WizardMoneyNpc.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine("Отлично, вот твои деньги.");
                                Money = Money + 250;
                                Console.WriteLine($"У вас теперь {Money} монет.");
                                NpcReward = true;
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Ах ты ж сука! На тебе!");
                                Console.WriteLine("Y - Защитить лицо руками от удара, N - Присесть.");
                                ConsoleKeyInfo Fight = Console.ReadKey(true);
                                switch (Fight.Key)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine("Он ударил вам в висок, пока вы судорожно прикрывали лицо. Он нанес вам 20 урона.");
                                        PlayerHp = PlayerHp - 20;
                                        if (PlayerHp <= 0)
                                        {
                                            Console.WriteLine("Вы скончались от яростных ударов Вити.");
                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Ваше нынешнее здоровье - {PlayerHp}");
                                            Console.WriteLine("Он открылся перед нападением, находясь в кураже от удара.\n Y - Точный удар, N - Таран");
                                            ConsoleKeyInfo Fight6 = Console.ReadKey(true);
                                            switch (Fight6.Key)
                                            {
                                                case ConsoleKey.Y:
                                                    Console.WriteLine("Он схватил вашу руку и заломал ее. Вы проиграли. Вы будете умирать долго и мучительно.");
                                                    Environment.Exit(0);
                                                    break;
                                                case ConsoleKey.N:
                                                    Console.WriteLine("Повалив его, он сильно ударился головой, оставалось только добить его.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                                    Environment.Exit(0);
                                                    break;
                                            }
                                        }

                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Вам попался удачный момент для удара, когда Витя раскрылся и замахнулся на вас.\nY - Апперкот, N - Удар по паху.");
                                        ConsoleKeyInfo Fight3 = Console.ReadKey(true);
                                        switch (Fight3.Key)
                                        {
                                            case ConsoleKey.Y:
                                                if (Strenght == true)
                                                {
                                                    Console.WriteLine("Вы сокрушающе ударили Витю, отчего он упал замертво.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Этот удар нанес сильный урон Вите. Он потянул руки к носу и согнулся.\n Y - Добить ударом колена. N - Ударить кулаком по затылку.");
                                                    ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                                    switch (Fight5.Key)
                                                    {
                                                        case ConsoleKey.Y:
                                                            if (Strenght == true)
                                                            {
                                                                Console.WriteLine("Хоть он и прикрывался руками, вы пробили его защиту.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                                NpcKilled = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Вы не смогли пробить его защиту из рук. Он контратаковал, воспользуясь вашим смятением.\nВы умерли.");
                                                                Environment.Exit(0);
                                                            }
                                                            break;
                                                        case ConsoleKey.N:
                                                            Console.WriteLine("Сильный удар прекратил существование Вити.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                            NpcKilled = true;
                                                            break;
                                                        default:
                                                            Console.WriteLine("Вы бездействовали и вас убили.");
                                                            Environment.Exit(0);
                                                            break;
                                                    }
                                                }
                                                break;
                                            case ConsoleKey.N:
                                                Console.WriteLine("Витя согнулся и раскрыл лицо для удара.");
                                                Console.WriteLine("Y - Добить ударом колена, N - Завершающий апперкот.");
                                                ConsoleKeyInfo Fight4 = Console.ReadKey(true);
                                                switch (Fight4.Key)
                                                {
                                                    case ConsoleKey.Y:
                                                        Console.WriteLine("Витя заблокировал ваш удар руками, уже притянутыми к носу. \n Вас повалили на пол. Y - Блокировать удары в голову, N - Резкий хук справа.");
                                                        ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                                        switch (Fight5.Key)
                                                        {
                                                            case ConsoleKey.Y:
                                                                Console.WriteLine("Вы умерли от бесчисленных ударов по печени.");
                                                                Environment.Exit(0);
                                                                break;
                                                            case ConsoleKey.N:
                                                                Console.WriteLine("Противник не ожидал хука, и подставился. Вы победили.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                                NpcKilled = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Вы бездействовали и вас убили.");
                                                                Environment.Exit(0);
                                                                break;
                                                        }
                                                        break;
                                                    case ConsoleKey.N:
                                                        Console.WriteLine("Точный и сильный удар не оставил противнику ни одного шанса. \nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                        NpcKilled = true;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                                        Environment.Exit(0);
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Вы бездействовали и вас убили.");
                                                Environment.Exit(0);
                                                break;
                                        }
                                        NpcKilled = true;
                                        break;
                                    default:
                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                        Environment.Exit(0);
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else if (WizardKill == true && NpcKilled == false)
                    {
                        Console.WriteLine("Ах ты ж сука! Я все слышал! На тебе!");
                        Console.WriteLine("Y - Защитить лицо руками от удара, N - Присесть.");
                        ConsoleKeyInfo Fight = Console.ReadKey(true);
                        switch (Fight.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine("Он ударил вам в висок, пока вы судорожно прикрывали лицо. Он нанес вам 20 урона.");
                                PlayerHp = PlayerHp - 20;
                                if (PlayerHp <= 0)
                                {
                                    Console.WriteLine("Вы скончались от яростных ударов Вити.");
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.WriteLine($"Ваше нынешнее здоровье - {PlayerHp}");
                                    Console.WriteLine("Он открылся перед нападением, находясь в кураже от удара.\n Y - Точный удар, N - Таран");
                                    ConsoleKeyInfo Fight6 = Console.ReadKey(true);
                                    switch (Fight6.Key)
                                    {
                                        case ConsoleKey.Y:
                                            Console.WriteLine("Он схватил вашу руку и заломал ее. Вы проиграли. Вы будете умирать долго и мучительно.");
                                            Environment.Exit(0);
                                            break;
                                        case ConsoleKey.N:
                                            Console.WriteLine("Повалив его, он сильно ударился головой, оставалось только добить его.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                            NpcKilled = true;
                                            break;
                                        default:
                                            Console.WriteLine("Вы бездействовали и вас убили.");
                                            Environment.Exit(0);
                                            break;
                                    }
                                }

                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Вам попался удачный момент для удара, когда Витя раскрылся и замахнулся на вас.\nY - Апперкот, N - Удар по паху.");
                                ConsoleKeyInfo Fight3 = Console.ReadKey(true);
                                switch (Fight3.Key)
                                {
                                    case ConsoleKey.Y:
                                        if (Strenght == true)
                                        {
                                            Console.WriteLine("Вы сокрушающе ударили Витю, отчего он упал замертво.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                            NpcKilled = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Этот удар нанес сильный урон Вите. Он потянул руки к носу и согнулся.\n Y - Добить ударом колена. N - Ударить кулаком по затылку.");
                                            ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                            switch (Fight5.Key)
                                            {
                                                case ConsoleKey.Y:
                                                    if (Strenght == true)
                                                    {
                                                        Console.WriteLine("Хоть он и прикрывался руками, вы пробили его защиту.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                        NpcKilled = true;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Вы не смогли пробить его защиту из рук. Он контратаковал, воспользуясь вашим смятением.\nВы умерли.");
                                                        Environment.Exit(0);
                                                    }
                                                    break;
                                                case ConsoleKey.N:
                                                    Console.WriteLine("Сильный удар прекратил существование Вити.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                    NpcKilled = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы бездействовали и вас убили.");
                                                    Environment.Exit(0);
                                                    break;
                                            }
                                        }
                                        break;
                                    case ConsoleKey.N:
                                        Console.WriteLine("Витя согнулся и раскрыл лицо для удара.");
                                        Console.WriteLine("Y - Добить ударом колена, N - Завершающий апперкот.");
                                        ConsoleKeyInfo Fight4 = Console.ReadKey(true);
                                        switch (Fight4.Key)
                                        {
                                            case ConsoleKey.Y:
                                                Console.WriteLine("Витя заблокировал ваш удар руками, уже притянутыми к носу. \n Вас повалили на пол. Y - Блокировать удары в голову, N - Резкий хук справа.");
                                                ConsoleKeyInfo Fight5 = Console.ReadKey(true);
                                                switch (Fight5.Key)
                                                {
                                                    case ConsoleKey.Y:
                                                        Console.WriteLine("Вы умерли от бесчисленных ударов по печени.");
                                                        Environment.Exit(0);
                                                        break;
                                                    case ConsoleKey.N:
                                                        Console.WriteLine("Противник не ожидал хука, и подставился. Вы победили.\nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                        NpcKilled = true;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                                        Environment.Exit(0);
                                                        break;
                                                }
                                                break;
                                            case ConsoleKey.N:
                                                Console.WriteLine("Точный и сильный удар не оставил противнику ни одного шанса. \nВы пресекли работорговлю и спасли семью волшебника ценой убийства.");
                                                NpcKilled = true;
                                                break;
                                            default:
                                                Console.WriteLine("Вы бездействовали и вас убили.");
                                                Environment.Exit(0);
                                                break;
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Вы бездействовали и вас убили.");
                                        Environment.Exit(0);
                                        break;
                                }
                                NpcKilled = true;
                                break;
                            default:
                                Console.WriteLine("Вы бездействовали и вас убили.");
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else if (NpcReward == false && NpcKilled == true)
                    {
                        Console.WriteLine("Вы смотрите на гниющий труп Вити. Поделом - думаете вы.");
                    }
                    else
                    {
                        Console.WriteLine("Привет!");
                    }
                }
                if (zone[y, x] == " X")
                {
                    y = yb;
                    x = xb;
                    if (TalkToNPC == false)
                    {
                        Console.WriteLine("Вы встретили монстра! Он опасен, лучше не драться с ним без причины.");
                    }
                    if (TalkToNPC == true && EnemyDead == true)
                    {
                        Console.WriteLine("Вы горделиво возвышаетесь над трупом поверженного монстра. \nДля других - это мелочь, а для вас - первая победа в вашем приключении.");
                    }
                    if ((TalkToNPC == true) && (EnemyDead == false))
                    {
                        Console.WriteLine("Вы встретили монстра, о котором говорил Витя!");
                        IsFight = true;
                        while ((PlayerHp > 0 && EnemyHp > 0) && IsFight)
                        {
                            Console.WriteLine("*Злобный рык*");
                            Console.WriteLine("W - Уйти, A - Атака оружием, D - Исцеление, S - Пропуск хода.");
                            ConsoleKeyInfo FightKey = Console.ReadKey(true);
                            switch (FightKey.Key)
                            {
                                case ConsoleKey.W:
                                    y--;
                                    IsFight = false;
                                    break;
                                case ConsoleKey.D:
                                    if (Potion > 0)
                                    {
                                        PlayerHp = PlayerHp + Heal - EnemyDmg + WeaponDef + ArmorDef;
                                        if (PlayerHp > 100)
                                        {
                                            PlayerHp = 100;
                                        }
                                        if (EnemyDmg - WeaponDef - ArmorDef > 0)
                                        {
                                            Console.WriteLine($"Вы выпили зелье! Но враг нанёс вам {EnemyDmg - WeaponDef - ArmorDef} урона. Ваше здоровье - {PlayerHp}.");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Вы выпили зелье! Враг не смог пробить вашу защиту! Ваше здоровье - {PlayerHp}");
                                        }
                                        Potion--;
                                        Console.WriteLine($"У вас осталось {Potion} зелий.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас не осталось зелий!");
                                    }
                                    break;
                                case ConsoleKey.A:
                                    PlayerHp = PlayerHp - (EnemyDmg - WeaponDef - ArmorDef);
                                    if (PlayerHp > 100)
                                    {
                                        PlayerHp = 100;
                                    }
                                    EnemyHp = EnemyHp - WeaponDmg - 5 - WizardHelp;
                                    Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                                    if (EnemyDmg - WeaponDef - ArmorDef > 0)
                                    {
                                        Console.WriteLine($"Враг нанес вам {EnemyDmg - WeaponDef - ArmorDef} урона!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Враг не смог пробить вашу защиту!");
                                    }
                                    if (EnemyHp > 0)
                                    {
                                        Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Здоровье врага - 0!");
                                    }
                                    break;
                                case ConsoleKey.S:
                                    if (EnemyDmg - WeaponDef - ArmorDef > 0)
                                    {
                                        PlayerHp = PlayerHp - (EnemyDmg - WeaponDef - ArmorDef);
                                        Console.WriteLine($"Враг нанес вам {EnemyDmg - WeaponDef - ArmorDef} урона!");
                                        Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Враг не смог пробить вашу защиту!");
                                        Console.WriteLine($"Ваше здоровье - {PlayerHp}.");
                                    }
                                    Console.WriteLine($"Здоровье врага - {EnemyHp}.");
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (PlayerHp >= 0 && EnemyHp <= 0)
                        {
                            Console.WriteLine($"Ура, победа!");
                            IsFight = false;
                            EnemyDead = true;
                        }
                        else if (PlayerHp <= 0 && EnemyHp >= 0)
                        {
                            Console.WriteLine("Вы умерли в схватке с монстром. Ваши кости обглоданы, Витя все еще в опасности, Монстр все еще живой.");
                            IsFight = false;
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Вы успешно сбежали.");
                            IsFight = false;
                        }
                    }
                }
                if (zone[y, x] == " D")
                {
                    y = yb;
                    x = xb;
                    if (PlayerHp >= 100)
                    {
                        Console.WriteLine("Здравствуй! Я доктор, если тебе нужна помощь, то я могу вылечить тебя за 20 монет.");
                    }
                    else if (PlayerHp < 100)
                    {
                        Console.WriteLine("Здравствуй! Вижу, ты немного ранен. Я могу вылечить тебя за 20 монет.\n Y - Принять N - Отказать");
                        ConsoleKeyInfo HealingDoctor = Console.ReadKey(true);
                        switch (HealingDoctor.Key)
                        {
                            case ConsoleKey.Y:
                                if (Money >= 20)
                                {
                                    Money = Money - 20;
                                    PlayerHp = 100;
                                    Console.WriteLine("Paratus! Вы полностью излечены.");
                                    Console.WriteLine($"У вас теперь {Money} монет.");
                                }
                                else
                                {
                                    Console.WriteLine("У вас недостаточно денег.");
                                }
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Ut dicis.");
                                break;
                        }
                    }
                }
                if (zone[y, x] == " O")
                {
                    int TrapDamage = rnd.Next(5, 15);
                    PlayerHp = PlayerHp - TrapDamage;
                    if (PlayerHp > 0)
                    {
                        Console.WriteLine($"Вы попали в ловушку и получили {TrapDamage} урона! Ваше нынешнее здоровье - {PlayerHp}");
                    }
                    else
                    {
                        PlayerHp = 0;
                        Console.WriteLine("Увы и ах, вы умерли от попадания в ловушку! Впредь будьте осторожнее...");
                        Environment.Exit(0);
                    }
                }
                if (zone[y, x] == " U")
                {
                    y = yb;
                    x = xb;
                    Console.WriteLine("Вы стоите перед огромными дверьми Короля Чернокнижников. Чтобы открыть их, нужна немалая сила.\nПопытаться открыть их? Y - Да N - Нет");
                    ConsoleKeyInfo WarlockDoor = Console.ReadKey(true);
                    switch (WarlockDoor.Key)
                    {
                        case ConsoleKey.Y:
                            if (Strenght == true)
                            {
                                Console.WriteLine("Вы успешно открыли дверь, приложив немалую силу, которая, благо, у вас имеется!");
                                if (x == 11)
                                {
                                    x = x - 2;
                                }
                                else if (x == 9)
                                {
                                    x = x + 2;
                                }
                            }
                            else
                            {
                                int DoorDmg = rnd.Next(1, 20);
                                PlayerHp = PlayerHp - DoorDmg;
                                Console.WriteLine($"Хоть вы и применили всю свою силу, открыть дверь не удалось. Вы растянули мышцы и получили {DoorDmg} урона.\nВаше нынешнее здоровье - {PlayerHp}.");
                            }
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine("Вы решили не открывать двери.\nНа мгновение вам показалось, что дверь хочет, чтобы вы ее открыли.");
                            break;
                        default:
                            break;
                    }
                }
                if (zone[y, x] == " !")
                {
                    Console.WriteLine("Управление - WASD. Выход - Esc. ");
                }
                if (zone[y, x] == " W")
                {
                    y = yb;
                    x = xb;
                    Console.WriteLine("Приветствую.");
                    if (Book == true && SecondQuest == false || Book == true && WizardReward == true)
                    {
                        Console.WriteLine("Ого. Утопия. Не думал что встречу ее здесь. \nСтавлю свою мантию на то, что торговец пытался выманить ее у тебя, так ведь?\nСлушай, это книга древнего Архивариуса Антонидаса. \nЯ могу изучить ее, чтобы улучшить твои, и разумеется, свои боевые навыки.\nНо после этого книга пропадет, на ней стоит заклинание.\n Y - Принять N - Отказаться");
                        ConsoleKeyInfo WizardDeal = Console.ReadKey(true);
                        switch (WizardDeal.Key)
                        {
                            case ConsoleKey.Y:
                                WizardHelp = 10;
                                Console.WriteLine("Спасибо, ты поступил правильно. Твои боевые навыки должны были возрасти.");
                                Console.WriteLine("Ваш урон возрос на 10 очков!");
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Жаль. Я буду ждать здесь, быть может, передумаешь.");
                                break;
                            default:
                                break;
                        }
                    }
                    else if (SecondQuest == true && WizardKill == false && WizardMoney == false)
                    {
                        Console.WriteLine("Тебя прислал Витя, так? Мда, плохо получается.\nПослушай, он плохой человек. Он шантажирует меня держа мою семью в заложниках наверху.\nОн не тот, кого за себя выдает. \nУбей его, и я дам тебе в два раза больше чем дал бы он.");
                        Console.WriteLine("Y - Хорошо, я сделаю это. N - Долг есть долг. Возвращай.");
                        ConsoleKeyInfo NpcKill = Console.ReadKey(true);
                        switch (NpcKill.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine("Я рассчитываю на тебя. Сделай всем нам одолжение.");
                                WizardKill = true;
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine("Эх. Держи свои деньги.");
                                WizardMoney = true;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (NpcKilled == true && WizardReward == false)
                    {
                        Console.WriteLine("Спасибо тебе. Большое тебе спасибо. Вот твои деньги. Моя семья и я будем тебе благодарны всю жизнь.");
                        Money = Money + 500;
                        Console.WriteLine($"У вас теперь {Money} монет.");
                        WizardReward = true;
                    }
                }
                if (zone[y, x] == " G")
                {
                    y = yb;
                    x = xb;
                    Console.WriteLine("Ты находишься в покоях Короля Чернокнижников. Если у тебя нет дела ко мне - проваливай.");
                }
                if (zone[y, x] == " %")
                {
                    y = yb;
                    x = xb;
                    if (TalkToTrainer == false) 
                    { 
                        Console.WriteLine("Перед вами лежат гантели. Для вас они не имеют никакого значения.");
                    }
                    else 
                    {
                        Console.WriteLine("Это гантели, о которых говорил Тренер. Вы используете их чтобы повысить свои силовые навыки.");
                        Strenght = true;
                        Console.WriteLine("Вы стали сильнее!");
                    }

                }
                if (zone[y, x] == " T")
                {
                    y = yb;
                    x = xb;   
                    if (Strenght == false)
                    {
                        Console.WriteLine("Привет, салага! Я тренер. Могу стать и твоим. \nЕсли согласен, бери гантели справа от меня и занимайся на здоровье.");
                        TalkToTrainer = true;
                    }
                    else
                    {
                        Console.WriteLine("Ого, уже виден прогресс! Продолжай в том же духе!");
                    }
                }
                if (zone[y, x] == " )" && _proto_zone.ZoneId == 1) // Перемещение в зону 2
                {
                    y = yb;
                    x = xb;
                    x = 1;
                    _proto_zone.ZoneId = 2;
                }
                
                if (_proto_zone.ZoneId == 2 && zone[y, x] == " )") // Перемещение в зону 1
                {
                    y = yb;
                    x = xb;
                    x = 14;
                    _proto_zone.ZoneId = 1;
                }

                //Перезапись буфера

                yb = y;
                xb = x;

                //Создание поля / get
                _proto_zone.RenderPlayer(zone, y, x);

                //Заполнение поля / set

                switch (_proto_zone.ZoneId)
                {
                    case 1:
                        {
                            Console.Write($"Здоровье: {PlayerHp} Урон:{WeaponDmg + 5 + WizardHelp}\nМонет: {Money} Зелий: {Potion}\n");
                            Console.WriteLine($"x: {x} y: {y}");
                            Room1(zone, y, x);
                        }
                        break;
                    case 2:
                        {

                            Console.Write($"Здоровье: {PlayerHp} Урон:{WeaponDmg + 5}\nМонет: {Money} Зелий: {Potion}\n");
                            Console.WriteLine($"x: {x} y: {y}");
                            Room2(zone, y, x);
                        }
                        break;
                    default:
                        break;
                }

                //Управление
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.S:
                        y++;
                        break;
                    case ConsoleKey.W:
                        y--;
                        break;
                    case ConsoleKey.D:
                        x++;
                        break;
                    case ConsoleKey.A:
                        x--;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:

                        break;
                }
                Console.Clear();

            }
        }
    }
}

